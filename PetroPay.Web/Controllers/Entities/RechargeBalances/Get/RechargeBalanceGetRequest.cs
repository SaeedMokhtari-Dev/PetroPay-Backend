namespace PetroPay.Web.Controllers.Entities.RechargeBalances.Get
{
    public class RechargeBalanceGetRequest
    {
        public int? CompanyId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int? Status { get; set; }
    }
}
