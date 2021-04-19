using System.Threading.Tasks;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Web.Identity.Contexts;
using PetroPay.Web.Identity.Services;

namespace PetroPay.Web.Controllers.Auth.Logout
{
    public class LogoutHandler : ApiRequestHandler<LogoutRequest>
    {
        private readonly UserContext _userContext;
        private readonly RefreshTokenService _refreshTokenService;

        public LogoutHandler(UserContext userContext, RefreshTokenService refreshTokenService)
        {
            _userContext = userContext;
            _refreshTokenService = refreshTokenService;
        }

        protected override async Task<ActionResult> Execute(LogoutRequest request)
        {
            if (_userContext.IsAuthenticated)
            {
                await _refreshTokenService.DeactivateToken(request.Token, _userContext.UniqueId);
            }

            return ActionResult.Ok();
        }
    }
}
