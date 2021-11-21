using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.InvoiceSummary.Get
{
    public class InvoiceSummaryGetResponse
    {
        public int TotalCount { get; set; }
        public double SumInvoiceAmount { get; set; }
        public List<InvoiceSummaryGetResponseItem> Items { get; set; }
    }
    public class InvoiceSummaryGetResponseItem
    {
        public Guid Key { get; set; }
        public int InvoiceId { get; set; }
        public int CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public string InvoiceDataTime { get; set; }
        public string ServiceEnDescription { get; set; }
        public string ServiceArDescription { get; set; }
        public string CarIdNumber { get; set; }
        public double? InvoiceFuelConsumptionLiter { get; set; }
        public double? InvoiceAmount { get; set; }
        public string PaymentMethodName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public double? InvoiceOdometer { get; set; }
    }
}
