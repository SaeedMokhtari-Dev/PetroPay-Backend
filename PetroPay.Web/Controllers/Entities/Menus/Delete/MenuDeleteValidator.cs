using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Delete
{
    public class MenuDeleteValidator : AbstractValidator<MenuDeleteRequest>
    {
        public MenuDeleteValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty().WithMessage(ApiMessages.MenuMessage.IdRequired);
        }
    }
}
