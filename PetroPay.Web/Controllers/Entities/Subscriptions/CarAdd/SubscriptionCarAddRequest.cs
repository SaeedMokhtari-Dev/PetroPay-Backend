namespace PetroPay.Web.Controllers.Entities.Subscriptions.CarAdd
{
    public class SubscriptionCarAddRequest
    {
        public int SubscriptionId { get; set; }
        public int[] SubscriptionCarIds { get; set; }
    }
}
