using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Entities.Menus.Detail
{
    [Route(Endpoints.ApiMenuDetail)]
    [ApiExplorerSettings(GroupName = "Menu")]
    [Authorize(Policies.AdminUser)]
    public class MenuDetailController : ApiController<MenuDetailRequest>
    {
        public MenuDetailController(IApiRequestHandler<MenuDetailRequest> handler, IValidator<MenuDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
