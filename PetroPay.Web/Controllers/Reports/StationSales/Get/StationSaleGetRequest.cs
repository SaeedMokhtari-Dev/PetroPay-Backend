namespace PetroPay.Web.Controllers.Reports.StationSales.Get
{
    public class StationSaleGetRequest
    {
        public int? StationWorkerId { get; set; }   
        public string StationWorkerFname { get; set; }
        public string InvoiceFuelType { get; set; }
        public string InvoiceDataTimeFrom { get; set; }
        public string InvoiceDataTimeTo { get; set; }
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
