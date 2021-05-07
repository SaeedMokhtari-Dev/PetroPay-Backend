using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Cars.Edit
{
    public class CarEditValidator : AbstractValidator<CarEditRequest>
    {
        public CarEditValidator()
        {
            RuleFor(x => x.CarId).NotEmpty().WithMessage(ApiMessages.CarMessage.IdRequired);
            RuleFor(x => x.CarDriverPassword).MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.MinPasswordLengthError);
        }
    }
}
