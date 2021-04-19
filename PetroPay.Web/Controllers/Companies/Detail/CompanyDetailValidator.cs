using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Companies.Detail
{
    public class CompanyDetailValidator : AbstractValidator<CompanyDetailRequest>
    {
        public CompanyDetailValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage(ApiMessages.CompanyMessage.IdRequired);
        }
    }
}
