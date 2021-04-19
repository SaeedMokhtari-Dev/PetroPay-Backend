using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Bundles.Detail
{
    public class BundleDetailValidator : AbstractValidator<BundleDetailRequest>
    {
        public BundleDetailValidator()
        {
            RuleFor(x => x.BundlesId).NotEmpty().WithMessage(ApiMessages.BundleMessage.IdRequired);
        }
    }
}
