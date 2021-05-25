#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class CarSubscription
    {
        public int SubscriptionId { get; set; }
        public int CarId { get; set; }
        public bool? Invoiced { get; set; }

        public virtual Car Car { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
