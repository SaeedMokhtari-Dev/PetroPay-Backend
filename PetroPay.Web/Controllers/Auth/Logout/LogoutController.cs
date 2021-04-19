using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.Logout
{
    [Route(Endpoints.ApiAuthLogout)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class LogoutController : ApiController<LogoutRequest>
    {
        public LogoutController(IApiRequestHandler<LogoutRequest> handler, IValidator<LogoutRequest> validator) : base(handler, validator)
        {
        }
    }
}
