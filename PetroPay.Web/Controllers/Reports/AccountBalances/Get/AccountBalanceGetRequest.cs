namespace PetroPay.Web.Controllers.Reports.AccountBalances.Get
{
    public class AccountBalanceGetRequest
    {
        public bool ExportToFile { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
