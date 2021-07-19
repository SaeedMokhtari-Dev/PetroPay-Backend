using System.IO;
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
            var content = ReadFully(strm);
            return File(content, "application/pdf", "invoice.pdf");
            //return File(strm, "application/pdf", "invoice.pdf"); 
        }
        private byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}