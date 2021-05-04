namespace PetroPay.Web.Controllers.Subscriptions.Get
{
    public class SubscriptionGetRequest
    {
        public int? CompanyId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
