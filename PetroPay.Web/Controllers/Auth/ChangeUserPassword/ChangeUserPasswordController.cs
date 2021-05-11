using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.ChangeUserPassword
{
    [Route(Endpoints.ApiAuthChangeUserPassword)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class ChangeUserPasswordController : ApiController<ChangeUserPasswordRequest>
    {
        public ChangeUserPasswordController(IApiRequestHandler<ChangeUserPasswordRequest> handler, IValidator<ChangeUserPasswordRequest> validator) : base(handler, validator)
        {
        }
    }
}
