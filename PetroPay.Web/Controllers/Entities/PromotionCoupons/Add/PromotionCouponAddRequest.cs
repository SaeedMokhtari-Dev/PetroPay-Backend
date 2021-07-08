using System;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Add
{
    public class PromotionCouponAddRequest
    {
        public string CouponCode { get; set; }
        public decimal? CouponDiscountValue { get; set; }
        public string CouponActiveDate { get; set; }
        public string CouponEndDate { get; set; }
        public bool? CouponActive { get; set; }
    }
}
