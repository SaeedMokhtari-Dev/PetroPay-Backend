using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Reports.OdometerHistories.Get
{
    public class OdometerHistoryGetValidator : AbstractValidator<OdometerHistoryGetRequest>
    {
        public OdometerHistoryGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
