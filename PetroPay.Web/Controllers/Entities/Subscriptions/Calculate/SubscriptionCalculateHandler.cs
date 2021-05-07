using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Calculate
{
    public class SubscriptionCalculateHandler : ApiRequestHandler<SubscriptionCalculateRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IMapper _mapper;
        private readonly SubscriptionCalculator _subscriptionCalculator;

        public SubscriptionCalculateHandler(
            PetroPayContext context, IMapper mapper, SubscriptionCalculator subscriptionCalculator)
        {
            _context = context;
            _mapper = mapper;
            _subscriptionCalculator = subscriptionCalculator;
        }

        protected override async Task<ActionResult> Execute(SubscriptionCalculateRequest request)
        {
            SubscriptionCalculateResponse response = await _subscriptionCalculator.CalculateSubscriptionCost(request);

            if (response == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);

            return ActionResult.Ok(response);
        }
    }
}
