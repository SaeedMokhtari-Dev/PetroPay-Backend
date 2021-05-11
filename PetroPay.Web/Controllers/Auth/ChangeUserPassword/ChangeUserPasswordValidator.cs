using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.ChangeUserPassword
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordRequest>
    {
        public ChangeUserPasswordValidator()
        {
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage(ApiMessages.Auth.CurrentPasswordRequired);
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.Auth.MinPasswordLengthError);
            RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.Auth.MinPasswordLengthError);
        }
    }
}
