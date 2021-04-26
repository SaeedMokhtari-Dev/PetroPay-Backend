using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Cars.Delete
{
    public class CarDeleteValidator : AbstractValidator<CarDeleteRequest>
    {
        public CarDeleteValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage(ApiMessages.CarMessage.IdRequired);
        }
    }
}
