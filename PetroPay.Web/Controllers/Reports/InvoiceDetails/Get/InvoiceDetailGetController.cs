using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.InvoiceDetails.Get
{
    [Route(Endpoints.ApiInvoiceDetailGet)]
    [ApiExplorerSettings(GroupName = "InvoiceSummary")]
    public class InvoiceDetailGetController : ApiController<InvoiceDetailGetRequest>
    {
        public InvoiceDetailGetController(IApiRequestHandler<InvoiceDetailGetRequest> handler, IValidator<InvoiceDetailGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
