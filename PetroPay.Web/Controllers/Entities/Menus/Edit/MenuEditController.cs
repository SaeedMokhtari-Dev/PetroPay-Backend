using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Edit
{
    [Route(Endpoints.ApiMenuEdit)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize(Policies.AdminUser)]
    public class MenuEditController : ApiController<MenuEditRequest>
    {
        public MenuEditController(IApiRequestHandler<MenuEditRequest> handler, IValidator<MenuEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
