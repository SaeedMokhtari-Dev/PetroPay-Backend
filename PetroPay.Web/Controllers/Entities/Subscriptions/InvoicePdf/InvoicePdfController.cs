using Microsoft.AspNetCore.Mvc;
using PetroPay.Web.Configuration.Constants;
using PetroPay.Web.Services;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.InvoicePdf
{
    [ApiExplorerSettings(GroupName = "Subscription")]
    [Route(Endpoints.ApiSubscriptionInvoicePdf)]
    public class InvoicePdfController : Controller
    {
        private readonly ReportService _reportService;
        public InvoicePdfController(ReportService reportService)
        {
            _reportService = reportService;
        }
        // GET
        [HttpPost]
        public FileResult Post(int invoiceNumber)
        {
            var strm = _reportService.GetInvoicePdf(invoiceNumber);
            return File(strm, "application/pdf", "invoice.pdf"); 
        }
    }
}