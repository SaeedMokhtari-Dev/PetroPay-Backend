using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Reports.CarOdometerMaxes.Get
{
    public class CarOdometerMaxGetValidator : AbstractValidator<CarOdometerMaxGetRequest>
    {
        public CarOdometerMaxGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
