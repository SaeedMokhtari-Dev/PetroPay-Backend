using FluentValidation;

namespace PetroPay.Web.Controllers.Entities.PromotionCoupons.Add
{
    public class PromotionCouponAddValidator : AbstractValidator<PromotionCouponAddRequest>
    {
        public PromotionCouponAddValidator()
        {
            /*RuleFor(x => x.AuditingPromotionCouponId).NotEmpty().WithMessage(ApiMessages.PromotionCouponMessage.AuditingPromotionCouponIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.PromotionCouponMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.PromotionCouponMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.PromotionCouponMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.PromotionCouponMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.PromotionCouponMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.PromotionCouponMessage.FunctionRequired);*/
            
        }
    }
}
