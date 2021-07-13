using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Subscriptions.Invoice
{
    public class SubscriptionInvoiceValidator : AbstractValidator<SubscriptionInvoiceRequest>
    {
        public SubscriptionInvoiceValidator()
        {
            RuleFor(x => x.SubscriptionInvoiceId).NotEmpty().WithMessage(ApiMessages.SubscriptionMessage.IdRequired);
        }
    }
}
