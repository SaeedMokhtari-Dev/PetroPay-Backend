using System;

namespace PetroPay.Web.Controllers.Subscriptions.Add
{
    public class SubscriptionAddRequest
    {
        public int SubscriptionId { get; set; }
        public int? CompanyId { get; set; }
        public string BundlesId { get; set; }
        public int? SubscriptionCarNumbers { get; set; }
        public string SubscriptionPaymentMethod { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public decimal? SubscriptionCost { get; set; }
        public bool? SubscriptionActive { get; set; }
        public string PaymentReferenceNumber { get; set; }
    }
}
