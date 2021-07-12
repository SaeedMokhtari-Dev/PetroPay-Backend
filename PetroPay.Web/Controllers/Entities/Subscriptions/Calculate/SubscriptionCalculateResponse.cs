namespace PetroPay.Web.Controllers.Entities.Subscriptions.Calculate
{
    public class SubscriptionCalculateResponse
    {
        public int BundlesId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Tax { get; set; }
        public decimal VatRate { get; set; }
        public decimal Vat { get; set; }
        public int CouponId { get; set; }
        public decimal SubscriptionCost { get; set; }
    }
}
