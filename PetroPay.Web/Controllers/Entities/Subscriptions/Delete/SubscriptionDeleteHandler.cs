using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Delete
{
    public class SubscriptionDeleteHandler : ApiRequestHandler<SubscriptionDeleteRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;

        public SubscriptionDeleteHandler(
            PetroPayContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SubscriptionDeleteRequest request)
        {
            Subscription subscription = await _context.Subscriptions
                .FindAsync(request.SubscriptionId);

            if (subscription == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            if (subscription.SubscriptionActive ?? false)
            {
                return ActionResult.Error(ApiMessages.SubscriptionMessage.ActiveEntityDeleteNotAllowed);
            }
            
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.SubscriptionMessage.DeletedSuccessfully);
        }
    }
}
