using FluentValidation;

namespace PetroPay.Web.Controllers.Auth.RefreshAccess
{
    public class RefreshAccessTokenValidator : AbstractValidator<RefreshAccessTokenRequest>
    {
        public RefreshAccessTokenValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty();
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
