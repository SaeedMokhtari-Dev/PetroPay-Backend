using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Delete
{
    [Route(Endpoints.ApiMenuDelete)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize(Policies.AdminUser)]
    public class MenuDeleteController : ApiController<MenuDeleteRequest>
    {
        public MenuDeleteController(IApiRequestHandler<MenuDeleteRequest> handler, IValidator<MenuDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
