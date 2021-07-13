using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class Subscription
    {
        public Subscription()
        {
            CarSubscriptions = new HashSet<CarSubscription>();
        }

        public int SubscriptionId { get; set; }
        public int? CompanyId { get; set; }
        public int? BundlesId { get; set; }
        public int? SubscriptionCarNumbers { get; set; }
        public string SubscriptionPaymentMethod { get; set; }
        /// <summary>
        /// monthly yearly quartly
        /// </summary>
        public string SubscriptionType { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public decimal? SubscriptionCost { get; set; }
        public bool? SubscriptionActive { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public string SubscriptionPaymentDocPhoto { get; set; }
        public int? CouponId { get; set; }
        public string CouponCode { get; set; }
        public decimal? SubscriptionDiscountValues { get; set; }
        public decimal? SubscriptionVatTaxValue { get; set; }
        public decimal? SubscriptionTaxValue { get; set; }
        public double? SubscriptionInvoiceNumber { get; set; }
        public int? NumberOfDateDiff { get; set; }

        public virtual Bundle Bundles { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<CarSubscription> CarSubscriptions { get; set; }
    }
}
