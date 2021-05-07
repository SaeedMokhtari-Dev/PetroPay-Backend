using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.CarAdd
{
    [Route(Endpoints.ApiSubscriptionCarAdd)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    public class SubscriptionCarAddController : ApiController<SubscriptionCarAddRequest>
    {
        public SubscriptionCarAddController(IApiRequestHandler<SubscriptionCarAddRequest> handler, IValidator<SubscriptionCarAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
