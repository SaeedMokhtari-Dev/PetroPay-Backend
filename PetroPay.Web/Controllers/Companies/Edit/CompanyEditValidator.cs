using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Companies.Edit
{
    public class CompanyEditValidator : AbstractValidator<CompanyEditRequest>
    {
        public CompanyEditValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.CompanyMessage.IdRequired);
        }
    }
}
