using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            Subscription editSubscription = await _context.Subscriptions.Include(w => w.CarSubscriptions)
                .SingleOrDefaultAsync(w => w.SubscriptionId == request.SubscriptionId);

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
                List<int> carIds = editSubscription.CarSubscriptions.Select(w => w.CarId).ToList();
                var shouldRemoveCarIds = carIds.Except(request.SubscriptionCarIds).ToList();
                foreach (var shouldRemoveCarId in shouldRemoveCarIds)
                {
                    var removeEntity = editSubscription.CarSubscriptions.Single(w => w.CarId == shouldRemoveCarId);
                    if (removeEntity.Invoiced != true)
                    {
                        _context.Remove(removeEntity);                        
                    }
                }
                
                var shouldAdded = request.SubscriptionCarIds.Except(carIds).ToList();
                foreach (var w in shouldAdded)
                {
                    editSubscription.CarSubscriptions.Add(new CarSubscription()
                    {
                        CarId = w,
                        SubscriptionId = editSubscription.SubscriptionId,
                        Invoiced = false
                    });
                }
                await _context.SaveChangesAsync();
                return editSubscription;
            });
        }
    }
}