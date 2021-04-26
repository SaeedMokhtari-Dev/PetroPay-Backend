using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.PetroStations.Edit
{
    public class PetroStationEditValidator : AbstractValidator<PetroStationEditRequest>
    {
        public PetroStationEditValidator()
        {
            RuleFor(x => x.StationId).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.IdRequired);
            RuleFor(x => x.StationPassword).MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.MinPasswordLengthError);
        }
    }
}
