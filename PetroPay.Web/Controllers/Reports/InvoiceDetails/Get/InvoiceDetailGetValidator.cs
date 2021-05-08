using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Reports.InvoiceDetails.Get
{
    public class InvoiceDetailGetValidator : AbstractValidator<InvoiceDetailGetRequest>
    {
        public InvoiceDetailGetValidator()
        {
            RuleFor(x => x.InvoiceId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
