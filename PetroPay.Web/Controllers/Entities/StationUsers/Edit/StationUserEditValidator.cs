using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.StationUsers.Edit
{
    public class StationUserEditValidator : AbstractValidator<StationUserEditRequest>
    {
        public StationUserEditValidator()
        {
            RuleFor(x => x.StationWorkerId).NotEmpty().WithMessage(ApiMessages.StationUserMessage.IdRequired);
            RuleFor(x => x.StationId).NotEmpty().WithMessage(ApiMessages.StationUserMessage.StationIdRequired);
            RuleFor(x => x.StationUserPassword).MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.MinPasswordLengthError);
        }
    }
}
