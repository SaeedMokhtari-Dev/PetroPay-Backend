using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Reports.InvoiceSummary.Get
{
    [Route(Endpoints.ApiInvoiceSummaryGet)]
    [ApiExplorerSettings(GroupName = "InvoiceSummary")]
    [Authorize]
    public class InvoiceSummaryGetController : ApiController<InvoiceSummaryGetRequest>
    {
        public InvoiceSummaryGetController(IApiRequestHandler<InvoiceSummaryGetRequest> handler, IValidator<InvoiceSummaryGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
