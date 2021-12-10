namespace PetroPay.Web.Controllers.Reports.StationStatements.Get
{
    public class StationStatementGetRequest
    {
        public int? CompanyId { get; set; }
        public int? StationId { get; set; }   
        public int? StationWorkerId { get; set; }   
        public string StationName { get; set; }
        public string InvoiceDataTimeFrom { get; set; }
        public string InvoiceDataTimeTo { get; set; }
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
