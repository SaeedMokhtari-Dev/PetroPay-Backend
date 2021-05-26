using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Calculate
{
    [Route(Endpoints.ApiSubscriptionCalculate)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    [Authorize]
    public class SubscriptionCalculateController : ApiController<SubscriptionCalculateRequest>
    {
        public SubscriptionCalculateController(IApiRequestHandler<SubscriptionCalculateRequest> handler, IValidator<SubscriptionCalculateRequest> validator) : base(handler, validator)
        {
        }
    }
}
