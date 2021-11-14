using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Detail
{
    public class PetrolCompanyDetailValidator : AbstractValidator<PetrolCompanyDetailRequest>
    {
        public PetrolCompanyDetailValidator()
        {
            RuleFor(x => x.PetrolCompanyId).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.IdRequired);
        }
    }
}
