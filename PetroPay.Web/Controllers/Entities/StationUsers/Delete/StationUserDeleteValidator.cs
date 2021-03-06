using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.StationUsers.Delete
{
    public class StationUserDeleteValidator : AbstractValidator<StationUserDeleteRequest>
    {
        public StationUserDeleteValidator()
        {
            RuleFor(x => x.StationWorkerId).NotEmpty().WithMessage(ApiMessages.StationUserMessage.IdRequired);
        }
    }
}
