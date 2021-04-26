using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.Token).NotEmpty().WithMessage(ApiMessages.Auth.TokenRequired);
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.Auth.MinPasswordLengthError);
            RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.Auth.MinPasswordLengthError);
        }
    }
}
