using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Edit
{
    public class PromotionCouponEditValidator : AbstractValidator<PromotionCouponEditRequest>
    {
        public PromotionCouponEditValidator()
        {
            RuleFor(x => x.CouponId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
