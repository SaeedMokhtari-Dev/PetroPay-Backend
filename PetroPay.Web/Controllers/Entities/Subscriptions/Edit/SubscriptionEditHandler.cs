using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Controllers.Entities.Subscriptions.Calculate;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Edit
{
    public class SubscriptionEditHandler : ApiRequestHandler<SubscriptionEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly SubscriptionCalculator _subscriptionCalculator;

        public SubscriptionEditHandler(
            PetroPayContext context, IMapper mapper, SubscriptionCalculator subscriptionCalculator)
        {
            _context = context;
            _mapper = mapper;
            _subscriptionCalculator = subscriptionCalculator;
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
            
            SubscriptionCalculateResponse subscriptionCost =
                await _subscriptionCalculator.CalculateSubscriptionCost(request.SubscriptionCarNumbers,
                    request.SubscriptionType, request.SubscriptionStartDate, request.SubscriptionEndDate);
            
            if(subscriptionCost == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            
            if(subscriptionCost.SubscriptionCost != request.SubscriptionCost)
                return ActionResult.Error(ApiMessages.InvalidRequest);

            await EditSubscription(editSubscription, request);
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.EditedSuccessfully);
        }

        private async Task EditSubscription(Subscription editSubscription, SubscriptionEditRequest request)
        {
            Subscription subscription = await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editSubscription);
                /*foreach (var w in request.SubscriptionCarIds)
                {
                    editSubscription.CarSubscriptions.Add(new CarSubscription()
                    {
                        CarId = w,
                        SubscriptionId = editSubscription.SubscriptionId
                    });
                }*/

                await _context.SaveChangesAsync();
                return editSubscription;
            });
        }
    }
}