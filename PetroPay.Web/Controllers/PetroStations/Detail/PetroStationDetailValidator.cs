using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.PetroStations.Detail
{
    public class PetroStationDetailValidator : AbstractValidator<PetroStationDetailRequest>
    {
        public PetroStationDetailValidator()
        {
            RuleFor(x => x.StationId).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.IdRequired);
        }
    }
}
