using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Delete
{
    [Route(Endpoints.ApiSubscriptionDelete)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    public class SubscriptionDeleteController : ApiController<SubscriptionDeleteRequest>
    {
        public SubscriptionDeleteController(IApiRequestHandler<SubscriptionDeleteRequest> handler, IValidator<SubscriptionDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
