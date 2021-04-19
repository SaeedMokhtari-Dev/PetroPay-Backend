using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Companies.Add
{
    public class CompanyAddValidator : AbstractValidator<CompanyAddRequest>
    {
        public CompanyAddValidator()
        {
            /*RuleFor(x => x.AuditingCompanyId).NotEmpty().WithMessage(ApiMessages.CompanyMessage.AuditingCompanyIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.CompanyMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.CompanyMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.CompanyMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.CompanyMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.CompanyMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.CompanyMessage.FunctionRequired);*/
            
        }
    }
}
