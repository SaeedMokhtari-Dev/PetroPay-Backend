using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.StationUsers.Detail
{
    public class StationUserDetailValidator : AbstractValidator<StationUserDetailRequest>
    {
        public StationUserDetailValidator()
        {
            RuleFor(x => x.StationWorkerId).NotEmpty().WithMessage(ApiMessages.StationUserMessage.IdRequired);
        }
    }
}
