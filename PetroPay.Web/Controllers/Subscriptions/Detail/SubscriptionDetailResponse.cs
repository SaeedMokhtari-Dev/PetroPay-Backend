using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Subscriptions.Detail
{
    public class SubscriptionDetailResponse
    {
        public int SubscriptionId { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? BundlesId { get; set; }
        public int? SubscriptionCarNumbers { get; set; }
        public string SubscriptionPaymentMethod { get; set; }
        public string SubscriptionType { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public decimal? SubscriptionCost { get; set; }
        public bool? SubscriptionActive { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public List<int> SubscriptionCarIds { get; set; }
    }
}
