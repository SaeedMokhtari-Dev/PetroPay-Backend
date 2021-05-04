using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Subscriptions.Active
{
    [Route(Endpoints.ApiSubscriptionActive)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    public class SubscriptionActiveController : ApiController<SubscriptionActiveRequest>
    {
        public SubscriptionActiveController(IApiRequestHandler<SubscriptionActiveRequest> handler, IValidator<SubscriptionActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
