using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.List
{
    [Route(Endpoints.ApiMenuList)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize(Policies.AdminUser)]
    public class MenuListController : ApiController<MenuListRequest>
    {
        public MenuListController(IApiRequestHandler<MenuListRequest> handler, IValidator<MenuListRequest> validator) : base(handler, validator)
        {
        }
    }
}
