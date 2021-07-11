using FluentValidation;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Add
{
    public class EmployeeMenuAddValidator : AbstractValidator<EmployeeMenuAddRequest>
    {
        public EmployeeMenuAddValidator()
        {
            /*RuleFor(x => x.AuditingEmployeeMenuId).NotEmpty().WithMessage(ApiMessages.EmployeeMenuMessage.AuditingEmployeeMenuIdRequired);
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(ApiMessages.EmployeeMenuMessage.FirstNameRequired);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ApiMessages.EmployeeMenuMessage.FirstNameRequired);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage(ApiMessages.EmployeeMenuMessage.EmailRequired);
            RuleFor(x => x.Fax).NotEmpty().WithMessage(ApiMessages.EmployeeMenuMessage.FaxRequired);
            RuleFor(x => x.Phone).NotEmpty().WithMessage(ApiMessages.EmployeeMenuMessage.PhoneRequired);
            RuleFor(x => x.Function).NotEmpty().WithMessage(ApiMessages.EmployeeMenuMessage.FunctionRequired);*/
            
        }
    }
}
