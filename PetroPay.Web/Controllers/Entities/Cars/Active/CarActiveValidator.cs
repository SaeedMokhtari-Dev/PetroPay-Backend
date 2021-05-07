using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Active
{
    public class CarActiveValidator : AbstractValidator<CarActiveRequest>
    {
        public CarActiveValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage(ApiMessages.CarMessage.IdRequired);
            RuleFor(x => x.CarNfcCode).NotEmpty().WithMessage(ApiMessages.CarMessage.CarNfcCodeRequired);
        }
    }
}
