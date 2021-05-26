using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Add
{
    [Route(Endpoints.ApiSubscriptionAdd)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    [Authorize]
    public class SubscriptionAddController : ApiController<SubscriptionAddRequest>
    {
        public SubscriptionAddController(IApiRequestHandler<SubscriptionAddRequest> handler, IValidator<SubscriptionAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
