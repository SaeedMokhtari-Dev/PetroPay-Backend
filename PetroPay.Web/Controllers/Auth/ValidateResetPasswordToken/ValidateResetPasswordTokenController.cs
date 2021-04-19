using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.ValidateResetPasswordToken
{
    [Route(Endpoints.ApiAuthValidateResetPasswordToken)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class ValidateResetPasswordTokenController : ApiController<ValidateResetPasswordTokenRequest>
    {
        public ValidateResetPasswordTokenController(IApiRequestHandler<ValidateResetPasswordTokenRequest> handler, IValidator<ValidateResetPasswordTokenRequest> validator) : base(handler, validator)
        {
        }
    }
}
