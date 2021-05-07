namespace PetroPay.Web.Controllers.Reports.AccountBalances.Detail
{
    public class AccountBalanceDetailResponse
    {
        public int AccountId { get; set; }
        public string AccountTaype { get; set; }
        public string AccountName { get; set; }
        public decimal? SumTransAmount { get; set; }
    }
}
