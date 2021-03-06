using System;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Edit
{
    public class SubscriptionEditRequest
    {
        /*public int Key { get; set; }*/
        public int SubscriptionId { get; set; }
        public int BundlesId { get; set; }
        public int SubscriptionCarNumbers { get; set; }
        public string SubscriptionPaymentMethod { get; set; }
        public string SubscriptionType { get; set; }
        public string SubscriptionStartDate { get; set; }
        public string SubscriptionEndDate { get; set; }
        public int NumberOfDateDiff { get; set; }
        public decimal SubscriptionCost { get; set; }
        public bool PayFromCompanyBalance { get; set; }
        /*public bool? SubscriptionActive { get; set; }*/
        public string PaymentReferenceNumber { get; set; }
        public string SubscriptionPaymentDocPhoto { get; set; }

        public string CouponCode { get; set; }
        /*public DateTime? SubscriptionDate { get; set; }*/
        /*public int[] SubscriptionCarIds { get; set; }*/
    }
}
