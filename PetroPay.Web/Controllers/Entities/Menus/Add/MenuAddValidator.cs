using FluentValidation;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Add
{
    public class MenuAddValidator : AbstractValidator<MenuAddRequest>
    {
        public MenuAddValidator()
        {
        }
    }
}
