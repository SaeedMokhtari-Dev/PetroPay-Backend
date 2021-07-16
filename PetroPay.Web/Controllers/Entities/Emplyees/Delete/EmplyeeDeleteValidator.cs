using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Delete
{
    public class EmplyeeDeleteValidator : AbstractValidator<EmplyeeDeleteRequest>
    {
        public EmplyeeDeleteValidator()
        {
            RuleFor(x => x.EmployeesId).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.IdRequired);
        }
    }
}
