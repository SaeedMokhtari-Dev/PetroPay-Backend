using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Get
{
    public class PetropayAccountGetValidator : AbstractValidator<PetropayAccountGetRequest>
    {
        public PetropayAccountGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
