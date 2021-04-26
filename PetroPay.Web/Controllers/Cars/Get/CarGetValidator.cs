using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Cars.Get
{
    public class CarGetValidator : AbstractValidator<CarGetRequest>
    {
        public CarGetValidator()
        {
            RuleFor(x => x.CompanyBranchId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.CarMessage.CompanyBranchIdRequired);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
