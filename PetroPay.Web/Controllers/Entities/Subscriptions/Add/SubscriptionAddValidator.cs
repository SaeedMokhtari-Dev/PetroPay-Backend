using System;
using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Add
{
    public class SubscriptionAddValidator : AbstractValidator<SubscriptionAddRequest>
    {
        public SubscriptionAddValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.CompanyIdRequired);
            RuleFor(x => x.BundlesId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.BundleIdRequired);
            RuleFor(x => x.SubscriptionCarNumbers).GreaterThan(0).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionCarNumberRequired);
            RuleFor(x => x.SubscriptionCost).GreaterThan(0).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionCostRequired);
            RuleFor(x => x.SubscriptionPaymentMethod).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.SubscriptionPaymentMethodRequired);
            /*RuleFor(x => x.SubscriptionStartDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionStartDateRequired);
            RuleFor(x => x.SubscriptionEndDate).GreaterThan(x => x.SubscriptionStartDate).WithMessage(ApiMessages.SubscriptionMessage.SubscriptionEndDateRequired);*/
            
        }
    }
}
