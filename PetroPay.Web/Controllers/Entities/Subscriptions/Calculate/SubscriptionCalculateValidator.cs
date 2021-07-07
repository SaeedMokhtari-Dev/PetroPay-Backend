using System;
using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Calculate
{
    public class SubscriptionCalculateValidator : AbstractValidator<SubscriptionCalculateRequest>
    {
        public SubscriptionCalculateValidator()
        {
            RuleFor(x => x.BundlesId).GreaterThan(0).WithMessage(ApiMessages.SubscriptionMessage.BundleIdRequired);
            RuleFor(x => x.SubscriptionCarNumbers).GreaterThan(0).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionCarNumberRequired);
            /*RuleFor(x => x.SubscriptionStartDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionStartDateRequired);
            RuleFor(x => x.SubscriptionEndDate).GreaterThan(x => x.SubscriptionStartDate).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionEndDateRequired);*/
        }
    }
}
