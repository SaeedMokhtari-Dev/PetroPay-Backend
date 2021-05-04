using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Subscriptions.Edit
{
    public class SubscriptionEditHandler : ApiRequestHandler<SubscriptionEditRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public SubscriptionEditHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SubscriptionEditRequest request)
        {
            Subscription editSubscription = await _context.Subscriptions
                .FindAsync(request.SubscriptionId);

            if (editSubscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await EditSubscription(editSubscription, request);
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.EditedSuccessfully);
        }

        private async Task EditSubscription(Subscription editSubscription, SubscriptionEditRequest request)
        {
            Subscription subscription = await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editSubscription);
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