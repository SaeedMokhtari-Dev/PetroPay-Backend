using FluentValidation;

namespace PetroPay.Web.Controllers.Entities.NewCustomers.Add
{
    public class NewCustomerAddValidator : AbstractValidator<NewCustomerAddRequest>
    {
        public NewCustomerAddValidator()
        {
            /*RuleFor(x => x.AuditingNewCustomerId).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.AuditingNewCustomerIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.NewCustomerMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.NewCustomerMessage.FunctionRequired);*/
            
        }
    }
}
