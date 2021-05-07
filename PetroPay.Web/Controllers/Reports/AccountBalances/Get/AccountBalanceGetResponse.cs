using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Reports.AccountBalances.Get
{
    public class AccountBalanceGetResponse
    {
        public int TotalCount { get; set; }
        public List<AccountBalanceGetResponseItem> Items { get; set; }
    }
    public class AccountBalanceGetResponseItem
    {
        public int Key { get; set; }
        public int AccountId { get; set; }
        public string AccountTaype { get; set; }
        public string AccountName { get; set; }
        public decimal? SumTransAmount { get; set; }
    }
}
