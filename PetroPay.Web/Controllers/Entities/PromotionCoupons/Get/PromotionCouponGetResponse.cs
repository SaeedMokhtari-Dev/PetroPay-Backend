using System;
using System.Collections.Generic;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Get
{
    public class PromotionCouponGetResponse
    {
        public int TotalCount { get; set; }
        public List<PromotionCouponGetResponseItem> Items { get; set; }
    }
    public class PromotionCouponGetResponseItem
    {
        public int Key { get; set; }
        public string CouponCode { get; set; }
        public decimal? CouponDiscountValue { get; set; }
        public DateTime? CouponActiveDate { get; set; }
        public DateTime? CouponEndDate { get; set; }
        public bool? CouponActive { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}
