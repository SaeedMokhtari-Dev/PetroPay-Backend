using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Active
{
    public class SubscriptionActiveValidator : AbstractValidator<SubscriptionActiveRequest>
    {
        public SubscriptionActiveValidator()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.IdRequired);
        }
    }
}
