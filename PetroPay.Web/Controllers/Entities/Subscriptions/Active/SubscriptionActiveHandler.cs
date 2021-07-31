using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Extensions;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Active
{
    public class SubscriptionActiveHandler : ApiRequestHandler<SubscriptionActiveRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly SubscriptionService _subscriptionService;
        private readonly EmailService _emailService;
        public SubscriptionActiveHandler(
            PetroPayContext context, IMapper mapper, UserService userService, SubscriptionService subscriptionService, EmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _subscriptionService = subscriptionService;
            _emailService = emailService;
        }

        protected override async Task<ActionResult> Execute(SubscriptionActiveRequest request)
        {
            Subscription subscription = await _context.Subscriptions
                .FindAsync(request.SubscriptionId);

            if (subscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            if (subscription.SubscriptionActive.HasValue && subscription.SubscriptionActive.Value)
            {
                return ActionResult.Error(ApiMessages.InvalidRequest);
            }

            if (subscription.SubscriptionPaymentMethod == "CompanyBalance")
            {
                return ActionResult.Error(ApiMessages.InvalidRequest);
            }

            Company company = await _context.Companies.FindAsync(subscription.CompanyId);
            
            if(company == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            /*if (subscription.SubscriptionPaymentMethod == "CompanyBalance")
            {
                if((!company.CompanyBalnce.HasValue) || company.CompanyBalnce.Value < subscription.SubscriptionCost)
                    return ActionResult.Error(ApiMessages.NotEnoughBalance);

                company.CompanyBalnce -= subscription.SubscriptionCost ?? 0;
            }*/
            PetropayAccount selectedPetropayAccount =
                await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccName == subscription.SubscriptionPaymentMethod);
            if (selectedPetropayAccount == null)
                throw new Exception("selected Petropay Account Subscriptions does not found.");
            /*if(selectedPetropayAccount.AccBalance < subscription.SubscriptionCost)
                return ActionResult.Error(ApiMessages.NotEnoughBalance);*/

            var user = await _userService.GetCurrentUserInfo();
            
            selectedPetropayAccount.AccBalance -= subscription.SubscriptionCost;
            TransAccount deductFromCompany = new TransAccount()
            {
                AccountId = selectedPetropayAccount.AccountId,
                TransAmount = -1 * (subscription.SubscriptionCost),
                TransDate = DateTime.Now.GetEgyptDateTime(),
                TransDocument = "pay subscription",
                TransReference = company.AccountId.ToString()
            };
            
            if (user.Item1)
            {
                deductFromCompany.UserId = user.Item2.Id;
                deductFromCompany.UserName = user.Item2.Name;
                deductFromCompany.UserType = user.Item2.Role.GetDisplayName();
            }
            deductFromCompany = (await _context.TransAccounts.AddAsync(deductFromCompany)).Entity;
            
            PetropayAccount subscriptionsPetropayAccount =
                await _context.PetropayAccounts.FirstOrDefaultAsync(w => w.AccSubscriptionRequst.HasValue && w.AccSubscriptionRequst == true);
            if (subscriptionsPetropayAccount == null)
                throw new Exception("PetropayAccount Subscriptions does not found.");
                    
            subscriptionsPetropayAccount.AccBalance += subscription.SubscriptionCost;
                    
            TransAccount addToSubscriptionAccount = new TransAccount()
            {
                AccountId = subscriptionsPetropayAccount.AccountId,
                TransAmount = subscription.SubscriptionCost,
                TransDate = DateTime.Now.GetEgyptDateTime(),
                TransDocument = "pay subscription",
                TransReference = company.AccountId.ToString()
            };
            
            if (user.Item1)
            {
                addToSubscriptionAccount.UserId = user.Item2.Id;
                addToSubscriptionAccount.UserName = user.Item2.Name;
                addToSubscriptionAccount.UserType = user.Item2.Role.GetDisplayName();
            }
            addToSubscriptionAccount = (await _context.TransAccounts.AddAsync(addToSubscriptionAccount)).Entity;

            subscription.SubscriptionActive = true;
            subscription.SubscriptionInvoiceNumber = await _subscriptionService.GetSubscriptionInvoiceNumber();
            await _context.SaveChangesAsync();
            
            await _emailService.SendSubscriptionInvoiceMail(company.CompanyAdminEmail, company.CompanyName,
                Convert.ToInt64(subscription.SubscriptionInvoiceNumber).ToString());
            
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.ActivatedSuccessfully);
        }
    }
}
