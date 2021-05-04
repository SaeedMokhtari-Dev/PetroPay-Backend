using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Subscriptions.Get
{
    [Route(Endpoints.ApiSubscriptionGet)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    public class SubscriptionGetController : ApiController<SubscriptionGetRequest>
    {
        public SubscriptionGetController(IApiRequestHandler<SubscriptionGetRequest> handler, IValidator<SubscriptionGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
