using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Subscriptions.Add
{
    public class SubscriptionAddValidator : AbstractValidator<SubscriptionAddRequest>
    {
        public SubscriptionAddValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.CompanyIdRequired);
            /*RuleFor(x => x.AuditingSubscriptionId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.AuditingSubscriptionIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.SubscriptionMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.FunctionRequired);*/
            
        }
    }
}
