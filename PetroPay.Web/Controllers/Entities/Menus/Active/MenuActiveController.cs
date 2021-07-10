using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Active
{
    [Route(Endpoints.ApiMenuActive)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize(Policies.AdminUser)]
    public class MenuActiveController : ApiController<MenuActiveRequest>
    {
        public MenuActiveController(IApiRequestHandler<MenuActiveRequest> handler, IValidator<MenuActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
