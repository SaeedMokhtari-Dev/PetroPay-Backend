using System.Collections.Generic;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class Bundle
    {
        public Bundle()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int BundlesId { get; set; }
        public int? BundlesNumberFrom { get; set; }
        public int? BundlesNumberTo { get; set; }
        public decimal? BundlesFeesMonthly { get; set; }
        public decimal? BundlesFeesYearly { get; set; }
        public decimal? BundlesNfcCost { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
