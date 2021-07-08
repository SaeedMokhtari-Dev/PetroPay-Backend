using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Detail
{
    public class PromotionCouponDetailValidator : AbstractValidator<PromotionCouponDetailRequest>
    {
        public PromotionCouponDetailValidator()
        {
            RuleFor(x => x.PromotionCouponsId).NotEmpty().WithMessage(ApiMessages.PromotionCouponMessage.IdRequired);
        }
    }
}
