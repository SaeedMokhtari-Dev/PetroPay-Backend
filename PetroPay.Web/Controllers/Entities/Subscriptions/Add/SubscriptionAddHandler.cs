using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Entities.Subscriptions.Calculate;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Add
{
    public class SubscriptionAddHandler : ApiRequestHandler<SubscriptionAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly SubscriptionCalculator _subscriptionCalculator;
        
        public SubscriptionAddHandler(
            PetroPayContext context, IMapper mapper, SubscriptionCalculator subscriptionCalculator)
        {
            this._context = context;
            this._mapper = mapper;
            _subscriptionCalculator = subscriptionCalculator;
        }

        protected override async Task<ActionResult> Execute(SubscriptionAddRequest request)
        {
            SubscriptionCalculateResponse subscriptionCost =
                await _subscriptionCalculator.CalculateSubscriptionCost(request.SubscriptionCarNumbers,
                    request.SubscriptionType, request.SubscriptionStartDate, request.SubscriptionEndDate);
            
            if(subscriptionCost == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            
            if(subscriptionCost.SubscriptionCost != request.SubscriptionCost)
                return ActionResult.Error(ApiMessages.InvalidRequest);
            
            Subscription subscription = await AddSubscription(request);
            
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.AddedSuccessfully);
        }
        
        private async Task<Subscription> AddSubscription(SubscriptionAddRequest request)
        {
            Subscription subscription = await _context.ExecuteTransactionAsync(async () =>
            {
                Subscription newSubscription = _mapper.Map<Subscription>(request);
                
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