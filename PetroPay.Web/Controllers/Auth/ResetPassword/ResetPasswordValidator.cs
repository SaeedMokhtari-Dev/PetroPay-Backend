using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Auth.ResetPassword
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.Auth.EmailRequired);
            RuleFor(x => x.RoleType).NotEmpty().WithMessage(ApiMessages.Auth.RoleTypeRequired);
        }
    }
}
