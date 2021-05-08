namespace PetroPay.Web.Controllers.Reports.CarTransactions.Get
{
    public class CarTransactionGetRequest
    {
        /*public string CarIdNumber { get; set; }
        public string CompanyBranchName { get; set; }
        public string InvoiceDataTimeFrom { get; set; }
        public string InvoiceDataTimeTo { get; set; }
        public string ServiceDescription { get; set; }*/
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }   
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
