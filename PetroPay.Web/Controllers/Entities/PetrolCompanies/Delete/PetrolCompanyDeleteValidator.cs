using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.Delete
{
    public class PetrolCompanyDeleteValidator : AbstractValidator<PetrolCompanyDeleteRequest>
    {
        public PetrolCompanyDeleteValidator()
        {
            RuleFor(x => x.PetrolCompanyId).NotEmpty().WithMessage(ApiMessages.PetrolCompanyMessage.IdRequired);
        }
    }
}
