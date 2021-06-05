using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.CarAdd
{
    public class SubscriptionCarAddValidator : AbstractValidator<SubscriptionCarAddRequest>
    {
        public SubscriptionCarAddValidator()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.IdRequired);
            //RuleFor(x => x.SubscriptionCarIds).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.SubscriptionCarIdsRequired);
        }
    }
}
