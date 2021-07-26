namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Get
{
    public class PetropayAccountGetRequest
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int? PetropayAccountId { get; set; }
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
