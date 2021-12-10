namespace PetroPay.Web.Controllers.Services.CurrentUserBalances.Get
{
    public class CurrentUserBalanceGetResponse
    {
        public CurrentUserBalanceGetResponse(decimal balance)
        {
            Balance = balance;
        }
        public decimal Balance { get; set; }
    }
}
