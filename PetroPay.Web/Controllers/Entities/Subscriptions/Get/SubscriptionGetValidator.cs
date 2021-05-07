using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Get
{
    public class SubscriptionGetValidator : AbstractValidator<SubscriptionGetRequest>
    {
        public SubscriptionGetValidator()
        {
            /*RuleFor(x => x.CompanyId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.SubscriptionMessage.CompanyIdRequired);*/
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
