using System;
using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Edit
{
    public class SubscriptionEditValidator : AbstractValidator<SubscriptionEditRequest>
    {
        public SubscriptionEditValidator()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.IdRequired);
            RuleFor(x => x.BundlesId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.BundleIdRequired);
            RuleFor(x => x.SubscriptionCarNumbers).GreaterThan(0).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionCarNumberRequired);
            RuleFor(x => x.SubscriptionCost).GreaterThan(0).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionCostRequired);
            RuleFor(x => x.SubscriptionPaymentMethod).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.SubscriptionPaymentMethodRequired);
            RuleFor(x => x.SubscriptionStartDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionStartDateRequired);
            RuleFor(x => x.SubscriptionEndDate).GreaterThan(x => x.SubscriptionStartDate).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionEndDateRequired);
        }
    }
}
