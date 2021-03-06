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
        public string UserType { get; set; }
        public int? CompanyId { get; set; }
        public bool? CouponForAllCustomer { get; set; }
        public bool? CouponForMonthly { get; set; }
        public bool? CouponForQuarterly { get; set; }
        public bool? CouponForYearly { get; set; }
    }
}
