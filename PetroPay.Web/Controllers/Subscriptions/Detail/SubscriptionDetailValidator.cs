using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Subscriptions.Detail
{
    public class SubscriptionDetailValidator : AbstractValidator<SubscriptionDetailRequest>
    {
        public SubscriptionDetailValidator()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.IdRequired);
        }
    }
}
