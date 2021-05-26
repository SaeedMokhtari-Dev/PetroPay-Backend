using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Companies.Edit
{
    public class CompanyEditValidator : AbstractValidator<CompanyEditRequest>
    {
        public CompanyEditValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.CompanyMessage.IdRequired);
            RuleFor(x => x.CompanyAdminUserPassword).Matches(PasswordConstants.PasswordRegex).WithMessage(ApiMessages.MinPasswordLengthError);
        }
    }
}
