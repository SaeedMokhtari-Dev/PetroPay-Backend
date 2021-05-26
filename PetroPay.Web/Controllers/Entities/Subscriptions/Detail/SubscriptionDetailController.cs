using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Detail
{
    [Route(Endpoints.ApiSubscriptionDetail)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    [Authorize]
    public class SubscriptionDetailController : ApiController<SubscriptionDetailRequest>
    {
        public SubscriptionDetailController(IApiRequestHandler<SubscriptionDetailRequest> handler, IValidator<SubscriptionDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
