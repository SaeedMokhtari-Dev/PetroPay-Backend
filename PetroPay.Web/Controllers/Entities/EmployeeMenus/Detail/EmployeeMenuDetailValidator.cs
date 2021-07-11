using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.EmployeeMenus.Detail
{
    public class EmployeeMenuDetailValidator : AbstractValidator<EmployeeMenuDetailRequest>
    {
        public EmployeeMenuDetailValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage(ApiMessages.EmployeeMenuMessage.IdRequired);
        }
    }
}
