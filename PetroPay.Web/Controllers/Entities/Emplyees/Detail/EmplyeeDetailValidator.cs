using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Emplyees.Detail
{
    public class EmplyeeDetailValidator : AbstractValidator<EmplyeeDetailRequest>
    {
        public EmplyeeDetailValidator()
        {
            RuleFor(x => x.EmplyeesId).NotEmpty().WithMessage(ApiMessages.EmplyeeMessage.IdRequired);
        }
    }
}
