using System.Threading.Tasks;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.CarAdd
{
    public class SubscriptionCarAddHandler : ApiRequestHandler<SubscriptionCarAddRequest>
    {
        private readonly PetroPayContext _context;

        public SubscriptionCarAddHandler(
            PetroPayContext context)
        {
            _context = context;
        }

        protected override async Task<ActionResult> Execute(SubscriptionCarAddRequest request)
        {
            Subscription editSubscription = await _context.Subscriptions
                .FindAsync(request.SubscriptionId);

            if (editSubscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
            
            if (editSubscription.SubscriptionActive == false)
            {
                return ActionResult.Error(ApiMessages.SubscriptionMessage.SubscriptionCarAddNotAllowed);
            }
            
            if(editSubscription.SubscriptionCarNumbers < request.SubscriptionCarIds.Length)
                return ActionResult.Error(ApiMessages.SubscriptionMessage.SubscriptionCarAddNotAllowed);
            
            await CarAddSubscription(editSubscription, request);
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.CarsAddedSuccessfully);
        }

        private async Task CarAddSubscription(Subscription editSubscription, SubscriptionCarAddRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                //_mapper.Map(request, editSubscription);
                foreach (var w in request.SubscriptionCarIds)
                {
                    editSubscription.CarSubscriptions.Add(new CarSubscription()
                    {
                        CarId = w,
                        SubscriptionId = editSubscription.SubscriptionId
                    });
                }
                await _context.SaveChangesAsync();
                return editSubscription;
            });
        }
    }
}