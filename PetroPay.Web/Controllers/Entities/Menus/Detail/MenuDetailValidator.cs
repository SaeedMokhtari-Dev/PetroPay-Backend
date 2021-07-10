using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Detail
{
    public class MenuDetailValidator : AbstractValidator<MenuDetailRequest>
    {
        public MenuDetailValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty().WithMessage(ApiMessages.MenuMessage.IdRequired);
        }
    }
}
