using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Active
{
    [Route(Endpoints.ApiSubscriptionActive)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    [Authorize]
    public class SubscriptionActiveController : ApiController<SubscriptionActiveRequest>
    {
        public SubscriptionActiveController(IApiRequestHandler<SubscriptionActiveRequest> handler, IValidator<SubscriptionActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
