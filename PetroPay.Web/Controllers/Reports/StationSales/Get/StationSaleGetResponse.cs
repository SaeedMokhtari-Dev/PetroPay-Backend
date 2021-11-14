using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.StationSales.Get
{
    public class StationSaleGetResponse
    {
        public int TotalCount { get; set; }
        public double SumInvoiceAmount { get; set; }
        public List<StationSaleGetResponseItem> Items { get; set; }
    }
    public class StationSaleGetResponseItem
    {
        public Guid Key { get; set; }
        public int StationWorkerId { get; set; }
        public string StationWorkerFname { get; set; }
        public double? SumInvoiceAmount { get; set; }
        public double? SumInvoiceFuelConsumptionLiter { get; set; }
        public string InvoiceFuelType { get; set; }
        public string SumInvoiceDataTime { get; set; }
    }
}
