using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.PetrolCompanies.List
{
    public class PetrolCompanyListValidator : AbstractValidator<PetrolCompanyListRequest>
    {
        public PetrolCompanyListValidator()
        {
        }
    }
}
