using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Delete
{
    public class NewCustomerDeleteValidator : AbstractValidator<NewCustomerDeleteRequest>
    {
        public NewCustomerDeleteValidator()
        {
            RuleFor(x => x.NewCustomerId).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.IdRequired);
        }
    }
}
