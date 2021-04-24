using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.PetroStations.Edit
{
    public class PetroStationEditValidator : AbstractValidator<PetroStationEditRequest>
    {
        public PetroStationEditValidator()
        {
            RuleFor(x => x.StationId).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.IdRequired);
        }
    }
}
