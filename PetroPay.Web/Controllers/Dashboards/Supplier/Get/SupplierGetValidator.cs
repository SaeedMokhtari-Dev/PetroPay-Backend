using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Dashboards.Supplier.Get
{
    public class SupplierGetValidator : AbstractValidator<SupplierGetRequest>
    {
        public SupplierGetValidator()
        {
            RuleFor(x => x.SupplierId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.CompanyMessage.IdRequired);
        }
    }
}
