using System;

#nullable disable

namespace PetroPay.DataAccess.Entities
{
    public partial class PromotionCoupon
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public decimal? CouponDiscountValue { get; set; }
        public DateTime? CouponActiveDate { get; set; }
        public DateTime? CouponEndDate { get; set; }
        public bool? CouponActive { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}
