using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Edit
{
    [Route(Endpoints.ApiSubscriptionEdit)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    public class SubscriptionEditController : ApiController<SubscriptionEditRequest>
    {
        public SubscriptionEditController(IApiRequestHandler<SubscriptionEditRequest> handler, IValidator<SubscriptionEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
