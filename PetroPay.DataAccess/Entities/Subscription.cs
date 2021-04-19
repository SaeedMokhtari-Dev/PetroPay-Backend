using System;
using System.Collections.Generic;

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
        public string BundlesId { get; set; }
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

        public virtual Company Company { get; set; }
        public virtual ICollection<CarSubscription> CarSubscriptions { get; set; }
    }
}
