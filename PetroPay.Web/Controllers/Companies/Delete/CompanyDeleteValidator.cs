using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Companies.Delete
{
    public class CompanyDeleteValidator : AbstractValidator<CompanyDeleteRequest>
    {
        public CompanyDeleteValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.CompanyMessage.IdRequired);
        }
    }
}
