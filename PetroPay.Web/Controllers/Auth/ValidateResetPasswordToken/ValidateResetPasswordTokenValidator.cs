using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Auth.ValidateResetPasswordToken
{
    public class ValidateResetPasswordTokenValidator : AbstractValidator<ValidateResetPasswordTokenRequest>
    {
        public ValidateResetPasswordTokenValidator()
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage(ApiMessages.Auth.TokenRequired);
        }
    }
}
