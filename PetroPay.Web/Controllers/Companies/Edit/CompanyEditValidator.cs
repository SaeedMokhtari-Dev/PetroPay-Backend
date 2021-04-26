using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Companies.Edit
{
    public class CompanyEditValidator : AbstractValidator<CompanyEditRequest>
    {
        public CompanyEditValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.CompanyMessage.IdRequired);
            RuleFor(x => x.CompanyAdminUserPassword).MinimumLength(IdentitySettings.MinPasswordLength).WithMessage(ApiMessages.MinPasswordLengthError);
        }
    }
}
