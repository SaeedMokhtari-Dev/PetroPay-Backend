namespace PetroPay.Web.Controllers.Entities.NewCustomers.Get
{
    public class NewCustomerGetRequest
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int? Status { get; set; }
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
