using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Cars.List
{
    public class CarListValidator : AbstractValidator<CarListRequest>
    {
        public CarListValidator()
        {
            RuleFor(x => x.CompanyId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.CarMessage.CompanyBranchIdRequired);
            
        }
    }
}
