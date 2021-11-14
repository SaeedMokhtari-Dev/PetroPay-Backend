using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Edit
{
    public class PetrolCompanyEditValidator : AbstractValidator<PetrolCompanyEditRequest>
    {
        public PetrolCompanyEditValidator()
        {
            RuleFor(x => x.PetrolCompanyId).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.IdRequired);
            RuleFor(x => x.PetrolCompanyAdminUserPassword).Matches(PasswordConstants.PasswordRegex).WithMessage(ApiMessages.MinPasswordLengthError);
        }
    }
}
