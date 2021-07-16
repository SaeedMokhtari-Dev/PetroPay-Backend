using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Edit
{
    public class EmplyeeEditValidator : AbstractValidator<EmplyeeEditRequest>
    {
        public EmplyeeEditValidator()
        {
            RuleFor(x => x.EmplyeeId).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.IdRequired);
        }
    }
}
