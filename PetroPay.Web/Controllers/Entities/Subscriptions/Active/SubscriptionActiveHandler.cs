using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Active
{
    public class SubscriptionActiveHandler : ApiRequestHandler<SubscriptionActiveRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public SubscriptionActiveHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            if(selectedPetropayAccount.AccBalance < subscription.SubscriptionCost)
                return ActionResult.Error(ApiMessages.NotEnoughBalance);

            selectedPetropayAccount.AccBalance -= subscription.SubscriptionCost;
            TransAccount deductFromCompany = new TransAccount()
            {
                AccountId = selectedPetropayAccount.AccountId,
                TransAmount = -1 * (subscription.SubscriptionCost),
                TransDate = DateTime.Now,
                TransDocument = "paySubscri",
                TransReference = company.AccountId.ToString()
            };
            deductFromCompany = (await _context.TransAccounts.AddAsync(deductFromCompany)).Entity;
            
            PetropayAccount subscriptionsPetropayAccount =
                await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccName == "Subscriptions");
            if (subscriptionsPetropayAccount == null)
                throw new Exception("PetropayAccount Subscriptions does not found.");
                    
            subscriptionsPetropayAccount.AccBalance += subscription.SubscriptionCost;
                    
            TransAccount addToSubscriptionAccount = new TransAccount()
            {
                AccountId = subscriptionsPetropayAccount.AccountId,
                TransAmount = subscription.SubscriptionCost,
                TransDate = DateTime.Now,
                TransDocument = "paySubscri",
                TransReference = company.AccountId.ToString()
            };
            addToSubscriptionAccount = (await _context.TransAccounts.AddAsync(addToSubscriptionAccount)).Entity;

            subscription.SubscriptionActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.ActivatedSuccessfully);
        }
    }
}
