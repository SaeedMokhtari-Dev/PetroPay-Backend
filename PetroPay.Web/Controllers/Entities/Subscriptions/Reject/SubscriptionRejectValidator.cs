using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Reject
{
    public class SubscriptionRejectValidator : AbstractValidator<SubscriptionRejectRequest>
    {
        public SubscriptionRejectValidator()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.IdRequired);
        }
    }
}
