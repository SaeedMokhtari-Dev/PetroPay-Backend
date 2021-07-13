using System;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Add
{
    public class SubscriptionAddRequest
    {
        public int CompanyId { get; set; }
        public int BundlesId { get; set; }
        public int SubscriptionCarNumbers { get; set; }
        public string SubscriptionPaymentMethod { get; set; }
        public bool PayFromCompanyBalance { get; set; }
        public string SubscriptionType { get; set; }
        public string SubscriptionStartDate { get; set; }
        public string SubscriptionEndDate { get; set; }
        public int NumberOfDateDiff { get; set; }
        public decimal SubscriptionCost { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public string SubscriptionPaymentDocPhoto { get; set; }
        public string CouponCode { get; set; }
    }
}
