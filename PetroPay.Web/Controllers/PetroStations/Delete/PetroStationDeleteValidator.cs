using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.PetroStations.Delete
{
    public class PetroStationDeleteValidator : AbstractValidator<PetroStationDeleteRequest>
    {
        public PetroStationDeleteValidator()
        {
            RuleFor(x => x.StationId).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.IdRequired);
        }
    }
}
