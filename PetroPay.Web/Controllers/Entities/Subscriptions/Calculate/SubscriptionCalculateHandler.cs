using System;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Extensions;

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
            DateTime startDate = DateTime.Now.GetEgyptDateTime();
            DateTime endDate = DateTime.Now.GetEgyptDateTime();
            
            if (!string.IsNullOrEmpty(request.SubscriptionStartDate))
            {
                startDate = DateTime.ParseExact(request.SubscriptionStartDate, DateTimeConstants.DateFormat, CultureInfo.InvariantCulture);
            }
            /*if (!string.IsNullOrEmpty(request.SubscriptionEndDate))
            {
                endDate = DateTime.ParseExact(request.SubscriptionEndDate, DateTimeConstants.DateFormat, CultureInfo.InvariantCulture);
            }*/
            
            SubscriptionCalculateResponse response = await _subscriptionCalculator.CalculateSubscriptionCost(request.BundlesId, request.SubscriptionCarNumbers,
                request.SubscriptionType, startDate, request.NumberOfDateDiff, request.CouponCode);

            if (response == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);

            return ActionResult.Ok(response);
        }
    }
}
