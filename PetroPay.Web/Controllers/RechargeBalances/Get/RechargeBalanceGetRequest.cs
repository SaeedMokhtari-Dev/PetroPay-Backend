namespace PetroPay.Web.Controllers.RechargeBalances.Get
{
    public class RechargeBalanceGetRequest
    {
        public int? CompanyId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
