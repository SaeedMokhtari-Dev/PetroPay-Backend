namespace PetroPay.Web.Controllers.Reports.StationReports.Get
{
    public class StationReportGetRequest
    {
        public int? StationWorkerId { get; set; }   
        public string StationWorkerFname { get; set; }
        public int? InvoiceId { get; set; }
        public string InvoiceDataTimeFrom { get; set; }
        public string InvoiceDataTimeTo { get; set; }
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
