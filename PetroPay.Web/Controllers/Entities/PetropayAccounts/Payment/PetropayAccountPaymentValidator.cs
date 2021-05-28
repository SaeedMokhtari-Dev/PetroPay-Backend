using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PetropayAccounts.Payment
{
    public class PetropayAccountPaymentValidator : AbstractValidator<PetropayAccountPaymentRequest>
    {
        public PetropayAccountPaymentValidator()
        {
            RuleFor(x => x.FromPetroPayAccountId).GreaterThan(0).WithMessage(ApiMessages.PetropayAccountMessage.FromPetroPayAccountIdRequired);
            RuleFor(x => x.ToPetroPayAccountId).GreaterThan(0).WithMessage(ApiMessages.PetropayAccountMessage.ToPetroPayAccountIdRequired);
            RuleFor(x => x.FromPetroPayAccountId).NotEqual(x => x.ToPetroPayAccountId)
                .WithMessage(ApiMessages.PetropayAccountMessage.PetroPayAccountsNotEqual);
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ApiMessages.PetropayAccountMessage.AmountRequired);
            RuleFor(x => x.Reference).NotEmpty().WithMessage(ApiMessages.PetropayAccountMessage.ReferenceRequired);
        }
    }
}
