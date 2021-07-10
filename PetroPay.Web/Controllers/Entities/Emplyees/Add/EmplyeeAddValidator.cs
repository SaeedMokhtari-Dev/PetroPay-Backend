using FluentValidation;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Add
{
    public class EmplyeeAddValidator : AbstractValidator<EmplyeeAddRequest>
    {
        public EmplyeeAddValidator()
        {
            /*RuleFor(x => x.AuditingEmplyeeId).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.AuditingEmplyeeIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.EmplyeeMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.FunctionRequired);*/
            
        }
    }
}
