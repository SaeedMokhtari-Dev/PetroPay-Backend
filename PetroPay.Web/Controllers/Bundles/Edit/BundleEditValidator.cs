using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Bundles.Edit
{
    public class BundleEditValidator : AbstractValidator<BundleEditRequest>
    {
        public BundleEditValidator()
        {
            RuleFor(x => x.BundlesId).NotEmpty().WithMessage(ApiMessages.BundleMessage.IdRequired);
        }
    }
}
