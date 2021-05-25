using System;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Calculate
{
    public class SubscriptionCalculateRequest
    {
        public int BundlesId { get; set; }
        public int SubscriptionCarNumbers { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
    }
}
