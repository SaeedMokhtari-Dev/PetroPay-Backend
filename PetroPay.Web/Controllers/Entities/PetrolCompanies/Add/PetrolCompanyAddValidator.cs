using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Add
{
    public class PetrolCompanyAddValidator : AbstractValidator<PetrolCompanyAddRequest>
    {
        public PetrolCompanyAddValidator()
        {
            RuleFor(x => x.PetrolCompanyAdminUserPassword).Matches(PasswordConstants.PasswordRegex).WithMessage(ApiMessages.MinPasswordLengthError);
            /*RuleFor(x => x.AuditingPetrolCompanyId).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.AuditingPetrolCompanyIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.PetrolCompanyMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.FunctionRequired);*/
            
        }
    }
}
