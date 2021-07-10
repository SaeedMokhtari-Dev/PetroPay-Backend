using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Active
{
    public class MenuActiveValidator : AbstractValidator<MenuActiveRequest>
    {
        public MenuActiveValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty().WithMessage(ApiMessages.MenuMessage.IdRequired);
        }
    }
}
