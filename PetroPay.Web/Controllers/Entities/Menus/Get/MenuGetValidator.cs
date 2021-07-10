using FluentValidation;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Get
{
    public class MenuGetValidator : AbstractValidator<MenuGetRequest>
    {
        public MenuGetValidator()
        {
            //RuleFor(x => x.CompanyBranchId).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.MenuMessage.CompanyBranchIdRequired);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
