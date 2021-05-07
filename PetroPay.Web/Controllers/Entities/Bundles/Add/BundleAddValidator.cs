using FluentValidation;

namespace PetroPay.Web.Controllers.Entities.Bundles.Add
{
    public class BundleAddValidator : AbstractValidator<BundleAddRequest>
    {
        public BundleAddValidator()
        {
            /*RuleFor(x => x.AuditingBundleId).NotEmpty().WithMessage(ApiMessages.BundleMessage.AuditingBundleIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.BundleMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.BundleMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.BundleMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.BundleMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.BundleMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.BundleMessage.FunctionRequired);*/
            
        }
    }
}
