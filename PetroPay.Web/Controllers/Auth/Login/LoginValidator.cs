using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Auth.Login
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(ApiMessages.Auth.UsernameRequired);
            RuleFor(x => x.Password).NotEmpty().WithMessage(ApiMessages.Auth.PasswordRequired);
            RuleFor(x => x.RoleType).NotEmpty().WithMessage(ApiMessages.Auth.RoleTypeRequired);
        }
    }
}
