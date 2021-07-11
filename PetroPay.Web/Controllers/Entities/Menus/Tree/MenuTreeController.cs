using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Tree
{
    [Route(Endpoints.ApiMenuTree)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize(Policies.AdminUser)]
    public class MenuTreeController : ApiController<MenuTreeRequest>
    {
        public MenuTreeController(IApiRequestHandler<MenuTreeRequest> handler, IValidator<MenuTreeRequest> validator) : base(handler, validator)
        {
        }
    }
}
