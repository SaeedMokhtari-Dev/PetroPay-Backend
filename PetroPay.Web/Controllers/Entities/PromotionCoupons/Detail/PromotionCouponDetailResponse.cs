using System;
using Itenso.TimePeriod;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Detail
{
    public class PromotionCouponDetailResponse
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public decimal? CouponDiscountValue { get; set; }
        public string CouponActiveDate { get; set; }
        public string CouponEndDate { get; set; }
        public bool? CouponActive { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? CompanyId { get; set; }
        public bool? CouponForAllCustomer { get; set; }
        public bool? CouponForMonthly { get; set; }
        public bool? CouponForQuarterly { get; set; }
        public bool? CouponForYearly { get; set; }
    }
}
