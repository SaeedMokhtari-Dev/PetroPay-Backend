namespace PetroPay.Web.Controllers.Entities.Subscriptions.Get
{
    public class SubscriptionGetRequest
    {
        public int? CompanyId { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int? Status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
