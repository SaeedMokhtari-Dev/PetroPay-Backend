using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.StationUsers.Edit
{
    public class StationUserEditValidator : AbstractValidator<StationUserEditRequest>
    {
        public StationUserEditValidator()
        {
            RuleFor(x => x.StationWorkerId).NotEmpty().WithMessage(ApiMessages.StationUserMessage.IdRequired);
            RuleFor(x => x.StationId).NotEmpty().WithMessage(ApiMessages.StationUserMessage.StationIdRequired);
        }
    }
}
