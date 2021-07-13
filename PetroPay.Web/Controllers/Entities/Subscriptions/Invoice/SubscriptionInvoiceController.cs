using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Invoice
{
    [Route(Endpoints.ApiSubscriptionInvoice)]
    [ApiExplorerSettings(GroupName = "Subscription")]
    [Authorize]
    public class SubscriptionInvoiceController : ApiController<SubscriptionInvoiceRequest>
    {
        public SubscriptionInvoiceController(IApiRequestHandler<SubscriptionInvoiceRequest> handler, IValidator<SubscriptionInvoiceRequest> validator) : base(handler, validator)
        {
        }
    }
}
