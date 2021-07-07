using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Entities.Subscriptions.Calculate;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Add
{
    public class SubscriptionAddHandler : ApiRequestHandler<SubscriptionAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly SubscriptionCalculator _subscriptionCalculator;
        private readonly UserContext _userContext;
        
        public SubscriptionAddHandler(
            PetroPayContext context, IMapper mapper, SubscriptionCalculator subscriptionCalculator, UserContext userContext)
        {
            this._context = context;
            this._mapper = mapper;
            _subscriptionCalculator = subscriptionCalculator;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(SubscriptionAddRequest request)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            
            if (!string.IsNullOrEmpty(request.SubscriptionStartDate))
            {
                startDate = DateTime.ParseExact(request.SubscriptionStartDate, DateTimeConstants.DateFormat, CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrEmpty(request.SubscriptionEndDate))
            {
                endDate = DateTime.ParseExact(request.SubscriptionEndDate, DateTimeConstants.DateFormat, CultureInfo.InvariantCulture);
            }
            
            SubscriptionCalculateResponse subscriptionCost =
                await _subscriptionCalculator.CalculateSubscriptionCost(request.BundlesId, request.SubscriptionCarNumbers,
                    request.SubscriptionType, startDate, endDate);
            
            if(subscriptionCost == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            
            if(subscriptionCost.SubscriptionCost != request.SubscriptionCost)
                return ActionResult.Error(ApiMessages.InvalidRequest);

            if (request.PayFromCompanyBalance && _userContext.Balance < subscriptionCost.SubscriptionCost)
                return ActionResult.Error(ApiMessages.NotEnoughBalance);
            
            if(!request.PayFromCompanyBalance && string.IsNullOrEmpty(request.SubscriptionPaymentMethod))
                return ActionResult.Error(ApiMessages.SubscriptionMessage.SubscriptionPaymentMethodRequired);
            
            Subscription subscription = await AddSubscription(request);
            
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.AddedSuccessfully);
        }
        
        private async Task<Subscription> AddSubscription(SubscriptionAddRequest request)
        {
            Subscription subscription = await _context.ExecuteTransactionAsync(async () =>
            {
                Subscription newSubscription = _mapper.Map<Subscription>(request);
                if (request.PayFromCompanyBalance)
                {
                    newSubscription.SubscriptionActive = true;
                    newSubscription.SubscriptionPaymentMethod = "CompanyBalance";
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

                    newSubscription.SubscriptionPaymentMethod = petropayAccount.AccName;
                }
                
                newSubscription = (await _context.Subscriptions.AddAsync(newSubscription)).Entity;
                
                /*foreach (var w in request.SubscriptionCarIds)
                {
                    newSubscription.CarSubscriptions.Add(new CarSubscription()
                    {
                        CarId = w,
                        SubscriptionId = newSubscription.SubscriptionId
                    });
                }*/
                
                await _context.SaveChangesAsync();

                return newSubscription;
            });
            return subscription;
        }
    }
}