using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Delete
{
    public class CarDeleteValidator : AbstractValidator<CarDeleteRequest>
    {
        public CarDeleteValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage(ApiMessages.CarMessage.IdRequired);
        }
    }
}
