using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.Login
{
    [Route(Endpoints.ApiAuthLogin)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class LoginController : ApiController<LoginRequest>
    {
        public LoginController(IApiRequestHandler<LoginRequest> handler, IValidator<LoginRequest> validator) : base(handler, validator)
        {
        }
    }
}
