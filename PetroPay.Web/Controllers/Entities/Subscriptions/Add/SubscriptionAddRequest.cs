using System;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Add
{
    public class SubscriptionAddRequest
    {
        public int CompanyId { get; set; }
        public int BundlesId { get; set; }
        public int SubscriptionCarNumbers { get; set; }
        public string SubscriptionPaymentMethod { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public decimal SubscriptionCost { get; set; }
        public string PaymentReferenceNumber { get; set; }
    }
}
