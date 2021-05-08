using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.StationReports.Get
{
    public class StationReportGetResponse
    {
        public int TotalCount { get; set; }
        public List<StationReportGetResponseItem> Items { get; set; }
    }
    public class StationReportGetResponseItem
    {
        public int Key { get; set; }
        public int StationWorkerId { get; set; }
        public string StationWorkerFname { get; set; }
        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceArDescription { get; set; }
        public string CarIdNumber { get; set; }
        public double? InvoiceAmount { get; set; }
        public string PaymentMethodName { get; set; }
        public DateTime? InvoiceDataTime { get; set; }
    }
}
