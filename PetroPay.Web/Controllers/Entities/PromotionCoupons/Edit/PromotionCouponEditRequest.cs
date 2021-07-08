using System;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Edit
{
    public class PromotionCouponEditRequest
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public decimal? CouponDiscountValue { get; set; }
        public DateTime? CouponActiveDate { get; set; }
        public DateTime? CouponEndDate { get; set; }
        public bool? CouponActive { get; set; }
    }
}
