using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FastReport;
using FastReport.Data;
using FastReport.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PetroPay.DataAccess.Contexts;
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
        [HttpGet]
        public async Task<FileResult> Get(int invoiceNumber)
        {
            var strm = await _reportService.GetInvoicePdf(invoiceNumber);
            return File(strm, "application/pdf", "report.pdf"); 
        }
    }
}