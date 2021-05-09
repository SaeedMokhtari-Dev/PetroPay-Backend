namespace PetroPay.Web.Controllers.Reports.StationStatements.Get
{
    public class StationStatementGetRequest
    {
        public int? StationId { get; set; }   
        public string StationName { get; set; }
        public string InvoiceDataTimeFrom { get; set; }
        public string InvoiceDataTimeTo { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
