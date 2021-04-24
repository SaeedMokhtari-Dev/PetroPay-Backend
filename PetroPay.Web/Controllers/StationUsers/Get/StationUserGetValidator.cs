using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.StationUsers.Get
{
    public class StationUserGetValidator : AbstractValidator<StationUserGetRequest>
    {
        public StationUserGetValidator()
        {
            RuleFor(x => x.StationId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.StationUserMessage.StationIdRequired);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
