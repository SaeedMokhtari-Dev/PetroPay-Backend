using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PetroStations.List
{
    public class PetroStationListValidator : AbstractValidator<PetroStationListRequest>
    {
        public PetroStationListValidator()
        {
        }
    }
}
