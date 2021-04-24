using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.StationUsers.Add
{
    public class StationUserAddValidator : AbstractValidator<StationUserAddRequest>
    {
        public StationUserAddValidator()
        {
            RuleFor(x => x.StationId).NotEmpty().WithMessage(ApiMessages.StationUserMessage.StationIdRequired);
            /*RuleFor(x => x.AuditingStationUserId).NotEmpty().WithMessage(ApiMessages.StationUserMessage.AuditingStationUserIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.StationUserMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.StationUserMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.StationUserMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.StationUserMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.StationUserMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.StationUserMessage.FunctionRequired);*/
            
        }
    }
}
