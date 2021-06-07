using System;
using System.Threading.Tasks;
using AutoMapper;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Entities.Subscriptions.Calculate;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Edit
{
    public class SubscriptionEditHandler : ApiRequestHandler<SubscriptionEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly SubscriptionCalculator _subscriptionCalculator;
        private readonly UserContext _userContext;

        public SubscriptionEditHandler(
            PetroPayContext context, IMapper mapper, SubscriptionCalculator subscriptionCalculator, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _subscriptionCalculator = subscriptionCalculator;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(SubscriptionEditRequest request)
        {
            Subscription editSubscription = await _context.Subscriptions
                .FindAsync(request.SubscriptionId);

            if (editSubscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            
            if (editSubscription.SubscriptionActive ?? false)
            {
                return ActionResult.Error(ApiMessages.SubscriptionMessage.ActiveEntityDeleteNotAllowed);
            }

            if (!request.SubscriptionStartDate.HasValue)
                request.SubscriptionStartDate = editSubscription.SubscriptionStartDate ?? DateTime.Now;
            
            if (!request.SubscriptionEndDate.HasValue)
                request.SubscriptionEndDate = editSubscription.SubscriptionEndDate ?? DateTime.Now;
            
            
            SubscriptionCalculateResponse subscriptionCost =
                await _subscriptionCalculator.CalculateSubscriptionCost(request.BundlesId, request.SubscriptionCarNumbers,
                    request.SubscriptionType, request.SubscriptionStartDate.Value, request.SubscriptionEndDate.Value);
            
            if(subscriptionCost == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            
            if(subscriptionCost.SubscriptionCost != request.SubscriptionCost)
                return ActionResult.Error(ApiMessages.InvalidRequest);

            if (request.PayFromCompanyBalance && _userContext.Balance < subscriptionCost.SubscriptionCost)
                return ActionResult.Error(ApiMessages.NotEnoughBalance);
            
            if(!request.PayFromCompanyBalance && string.IsNullOrEmpty(request.SubscriptionPaymentMethod))
                return ActionResult.Error(ApiMessages.SubscriptionMessage.SubscriptionPaymentMethodRequired);
            
            await EditSubscription(editSubscription, request);
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.EditedSuccessfully);
        }

        private async Task EditSubscription(Subscription editSubscription, SubscriptionEditRequest request)
        {
            Subscription subscription = await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editSubscription);
                if (request.PayFromCompanyBalance)
                {
                    editSubscription.SubscriptionActive = true;
                    editSubscription.SubscriptionPaymentMethod = "CompanyBalance";
                    Company company = await _context.Companies.SingleOrDefaultAsync(w => w.CompanyId == _userContext.Id);
                    company.CompanyBalnce -= request.SubscriptionCost;

                    TransAccount deductFromCompany = new TransAccount()
                    {
                        AccountId = company.AccountId,
                        TransAmount = -1 * (request.SubscriptionCost),
                        TransDate = DateTime.Now,
                        TransDocument = "paySubscri",
                        TransReference = company.AccountId.ToString()
                    };
                    deductFromCompany = (await _context.TransAccounts.AddAsync(deductFromCompany)).Entity;
                    PetropayAccount petropayAccount =
                        await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccName == "Subscriptions");
                    if (petropayAccount == null)
                        throw new Exception("PetropayAccount Subscriptions does not found.");
                    
                    petropayAccount.AccBalance += request.SubscriptionCost;
                    
                    TransAccount addToSubscriptionAccount = new TransAccount()
                    {
                        AccountId = petropayAccount.AccountId,
                        TransAmount = request.SubscriptionCost,
                        TransDate = DateTime.Now,
                        TransDocument = "paySubscri",
                        TransReference = company.AccountId.ToString()
                    };
                    addToSubscriptionAccount = (await _context.TransAccounts.AddAsync(addToSubscriptionAccount)).Entity;
                }
                else
                {
                    PetropayAccount petropayAccount =
                        await _context.PetropayAccounts.SingleOrDefaultAsync(w => w.AccName == request.SubscriptionPaymentMethod);
                    if (petropayAccount == null)
                        throw new Exception("PetropayAccount Subscriptions does not found.");

                    editSubscription.SubscriptionPaymentMethod = petropayAccount.AccName;
                }

                await _context.SaveChangesAsync();
                return editSubscription;
            });
        }
    }
}