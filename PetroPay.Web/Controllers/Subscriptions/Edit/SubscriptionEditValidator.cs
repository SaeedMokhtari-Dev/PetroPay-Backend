using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Subscriptions.Edit
{
    public class SubscriptionEditValidator : AbstractValidator<SubscriptionEditRequest>
    {
        public SubscriptionEditValidator()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.IdRequired);
            RuleFor(x => x.BundlesId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.BundleIdRequired);
        }
    }
}
