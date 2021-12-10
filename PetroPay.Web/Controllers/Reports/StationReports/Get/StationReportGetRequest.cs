namespace PetroPay.Web.Controllers.Reports.StationReports.Get
{
    public class StationReportGetRequest
    {
        public int? CompanyId { get; set; }
        public int? StationId { get; set; }   
        public int? StationWorkerId { get; set; }   
        public int? ServiceId { get; set; }   
        public string StationWorkerFname { get; set; }
        public int? InvoiceId { get; set; }
        public string InvoiceDataTimeFrom { get; set; }
        public string InvoiceDataTimeTo { get; set; }
        public string PaymentMethodName { get; set; }
        public string ServiceArDescription { get; set; }
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
