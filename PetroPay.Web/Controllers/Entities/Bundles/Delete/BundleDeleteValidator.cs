using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Bundles.Delete
{
    public class BundleDeleteValidator : AbstractValidator<BundleDeleteRequest>
    {
        public BundleDeleteValidator()
        {
            RuleFor(x => x.BundlesId).NotEmpty().WithMessage(ApiMessages.BundleMessage.IdRequired);
        }
    }
}
