using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Get
{
    [Route(Endpoints.ApiMenuGet)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize(Policies.AdminUser)]
    public class MenuGetController : ApiController<MenuGetRequest>
    {
        public MenuGetController(IApiRequestHandler<MenuGetRequest> handler, IValidator<MenuGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
