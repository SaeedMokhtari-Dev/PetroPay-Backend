using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.ResetPassword
{
    [Route(Endpoints.ApiAuthResetPassword)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class ResetPasswordController : ApiController<ResetPasswordRequest>
    {
        public ResetPasswordController(IApiRequestHandler<ResetPasswordRequest> handler, IValidator<ResetPasswordRequest> validator) : base(handler, validator)
        {
        }
    }
}
