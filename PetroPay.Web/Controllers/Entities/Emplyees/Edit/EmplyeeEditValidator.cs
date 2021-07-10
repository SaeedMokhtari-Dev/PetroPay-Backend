using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Edit
{
    public class EmplyeeEditValidator : AbstractValidator<EmplyeeEditRequest>
    {
        public EmplyeeEditValidator()
        {
            RuleFor(x => x.EmplyeesId).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.IdRequired);
        }
    }
}
