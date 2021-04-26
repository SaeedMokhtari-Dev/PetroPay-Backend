using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.ChangePassword
{
    [Route(Endpoints.ApiAuthChangePassword)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class ChangePasswordController : ApiController<ChangePasswordRequest>
    {
        public ChangePasswordController(IApiRequestHandler<ChangePasswordRequest> handler, IValidator<ChangePasswordRequest> validator) : base(handler, validator)
        {
        }
    }
}
