using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Interfaces;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.AuthCheck
{
    [Authorize(Policy = nameof(Policies.ActiveUser))]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class AuthCheckController: ControllerBase, IApiController
    {

        [HttpGet]
        [Route(Endpoints.ApiAuthCheck)]
        public IActionResult AuthCheck()
        {
            return ApiResponse.Ok();
        }
    }
}
