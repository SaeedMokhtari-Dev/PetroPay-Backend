using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Delete
{
    public class SubscriptionDeleteValidator : AbstractValidator<SubscriptionDeleteRequest>
    {
        public SubscriptionDeleteValidator()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.IdRequired);
        }
    }
}
