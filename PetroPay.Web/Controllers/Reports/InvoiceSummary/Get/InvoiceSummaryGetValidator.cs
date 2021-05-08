using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Reports.InvoiceSummary.Get
{
    public class InvoiceSummaryGetValidator : AbstractValidator<InvoiceSummaryGetRequest>
    {
        public InvoiceSummaryGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
