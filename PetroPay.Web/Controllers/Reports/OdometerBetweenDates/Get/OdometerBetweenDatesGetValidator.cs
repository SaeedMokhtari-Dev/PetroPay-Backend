using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Reports.OdometerBetweenDates.Get
{
    public class OdometerBetweenDateGetValidator : AbstractValidator<OdometerBetweenDateGetRequest>
    {
        public OdometerBetweenDateGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
