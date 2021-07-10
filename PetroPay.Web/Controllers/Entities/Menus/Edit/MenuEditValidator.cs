using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Edit
{
    public class MenuEditValidator : AbstractValidator<MenuEditRequest>
    {
        public MenuEditValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty().WithMessage(ApiMessages.MenuMessage.IdRequired);
        }
    }
}
