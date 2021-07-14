using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Edit
{
    public class NewCustomerEditValidator : AbstractValidator<NewCustomerEditRequest>
    {
        public NewCustomerEditValidator()
        {
            RuleFor(x => x.CustReqId).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.IdRequired);
        }
    }
}
