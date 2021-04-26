using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Cars.Detail
{
    public class CarDetailValidator : AbstractValidator<CarDetailRequest>
    {
        public CarDetailValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage(ApiMessages.CarMessage.IdRequired);
        }
    }
}
