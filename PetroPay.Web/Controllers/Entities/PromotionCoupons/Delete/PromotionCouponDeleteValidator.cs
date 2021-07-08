using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Delete
{
    public class PromotionCouponDeleteValidator : AbstractValidator<PromotionCouponDeleteRequest>
    {
        public PromotionCouponDeleteValidator()
        {
            RuleFor(x => x.PromotionCouponsId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
