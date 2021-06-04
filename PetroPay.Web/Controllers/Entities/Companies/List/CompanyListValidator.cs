using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Companies.List
{
    public class CompanyListValidator : AbstractValidator<CompanyListRequest>
    {
        public CompanyListValidator()
        {
        }
    }
}
