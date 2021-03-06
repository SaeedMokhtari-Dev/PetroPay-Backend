using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Detail
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
        public string SubscriptionStartDate { get; set; }
        public string SubscriptionEndDate { get; set; }
        public int NumberOfDateDiff { get; set; }
        public decimal? SubscriptionCost { get; set; }
        public bool? SubscriptionActive { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public string SubscriptionDate { get; set; }
        public string SubscriptionPaymentDocPhoto { get; set; }
        public bool PayFromCompanyBalance { get; set; }
        public int? PetropayAccountId { get; set; }
        public string CouponCode { get; set; }
        public List<SubscriptionCar> SubscriptionCars { get; set; }
    }
}
