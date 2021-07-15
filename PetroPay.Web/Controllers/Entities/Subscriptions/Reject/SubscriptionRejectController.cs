using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Reject
{
    [Route(Endpoints.ApiSubscriptionReject)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    [Authorize]
    public class SubscriptionRejectController : ApiController<SubscriptionRejectRequest>
    {
        public SubscriptionRejectController(IApiRequestHandler<SubscriptionRejectRequest> handler, IValidator<SubscriptionRejectRequest> validator) : base(handler, validator)
        {
        }
    }
}
