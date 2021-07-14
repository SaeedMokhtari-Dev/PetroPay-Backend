using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Active
{
    public class NewCustomerActiveValidator : AbstractValidator<NewCustomerActiveRequest>
    {
        public NewCustomerActiveValidator()
        {
            RuleFor(x => x.NewCustomerId).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.IdRequired);
        }
    }
}
