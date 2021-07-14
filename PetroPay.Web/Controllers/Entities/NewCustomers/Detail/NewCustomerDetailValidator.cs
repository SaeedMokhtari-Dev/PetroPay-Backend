using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Detail
{
    public class NewCustomerDetailValidator : AbstractValidator<NewCustomerDetailRequest>
    {
        public NewCustomerDetailValidator()
        {
            RuleFor(x => x.NewCustomerId).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.IdRequired);
        }
    }
}
