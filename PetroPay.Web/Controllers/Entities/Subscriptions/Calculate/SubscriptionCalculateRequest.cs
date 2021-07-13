using System;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Calculate
{
    public class SubscriptionCalculateRequest
    {
        public int BundlesId { get; set; }
        public int SubscriptionCarNumbers { get; set; }
        public string SubscriptionType { get; set; }
        public string SubscriptionStartDate { get; set; }
        //public string SubscriptionEndDate { get; set; }
        public int NumberOfDateDiff { get; set; }
        public string CouponCode { get; set; }
    }
}
