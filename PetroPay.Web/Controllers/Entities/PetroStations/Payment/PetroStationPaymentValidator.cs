using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PetroStations.Payment
{
    public class PetroStationPaymentValidator : AbstractValidator<PetroStationPaymentRequest>
    {
        public PetroStationPaymentValidator()
        {
            RuleFor(x => x.StationId).GreaterThan(0).WithMessage(ApiMessages.PetroStationMessage.IdRequired);
            RuleFor(x => x.PetroPayAccountId).GreaterThan(0).WithMessage(ApiMessages.PetroStationMessage.PetroPayAccountIdRequired);
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ApiMessages.PetroStationMessage.AmountRequired);
            RuleFor(x => x.Reference).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.ReferenceRequired);
        }
    }
}
