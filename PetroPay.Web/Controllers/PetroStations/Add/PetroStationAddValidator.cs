using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.PetroStations.Add
{
    public class PetroStationAddValidator : AbstractValidator<PetroStationAddRequest>
    {
        public PetroStationAddValidator()
        {
            /*RuleFor(x => x.Station).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.CompanyIdRequired);*/
            /*RuleFor(x => x.AuditingPetroStationId).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.AuditingPetroStationIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.PetroStationMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.PetroStationMessage.FunctionRequired);*/
            
        }
    }
}
