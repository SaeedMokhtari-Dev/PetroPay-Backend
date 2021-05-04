using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Subscriptions.Add
{
    public class SubscriptionAddHandler : ApiRequestHandler<SubscriptionAddRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        
        public SubscriptionAddHandler(
            PetroPayContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SubscriptionAddRequest request)
        {
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