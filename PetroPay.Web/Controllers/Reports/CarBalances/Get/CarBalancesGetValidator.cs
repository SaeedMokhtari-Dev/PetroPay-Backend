using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Reports.CarBalances.Get
{
    public class CarBalanceGetValidator : AbstractValidator<CarBalanceGetRequest>
    {
        public CarBalanceGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
