using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Dashboards.Customers.Get
{
    public class CustomerGetValidator : AbstractValidator<CustomerGetRequest>
    {
        public CustomerGetValidator()
        {
            RuleFor(x => x.CompanyId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.CompanyMessage.IdRequired);
        }
    }
}
