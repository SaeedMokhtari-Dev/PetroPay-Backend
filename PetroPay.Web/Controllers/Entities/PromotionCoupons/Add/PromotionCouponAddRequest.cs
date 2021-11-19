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
        
        public int? CompanyId { get; set; }
        public bool? CouponForAllCustomer { get; set; }
        public bool? CouponForMonthly { get; set; }
        public bool? CouponForQuarterly { get; set; }
        public bool? CouponForYearly { get; set; }
    }
}
