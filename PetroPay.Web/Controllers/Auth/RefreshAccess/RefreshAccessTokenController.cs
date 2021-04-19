using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PetroPay.Core.Api.Controllers;
using PetroPay.Core.Api.Handlers;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Controllers.Auth.RefreshAccess
{
    [Route(Endpoints.ApiAuthRefreshAccessToken)]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class RefreshAccessTokenController : ApiController<RefreshAccessTokenRequest>
    {
        public RefreshAccessTokenController(IApiRequestHandler<RefreshAccessTokenRequest> handler, IValidator<RefreshAccessTokenRequest> validator) : base(handler, validator)
        {
        }
    }
}
