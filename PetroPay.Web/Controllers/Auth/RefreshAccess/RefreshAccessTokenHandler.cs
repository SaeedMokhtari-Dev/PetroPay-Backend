using System;
using System.Threading.Tasks;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Web.Identity.Services;

namespace PetroPay.Web.Controllers.Auth.RefreshAccess
{
    public class RefreshAccessTokenHandler : ApiRequestHandler<RefreshAccessTokenRequest>
    {
        private readonly RefreshTokenService _refreshTokenService;
        private readonly AccessTokenService _accessTokenService;

        public RefreshAccessTokenHandler(RefreshTokenService refreshTokenService, AccessTokenService accessTokenService)
        {
            _refreshTokenService = refreshTokenService;
            _accessTokenService = accessTokenService;
        }

        protected override async Task<ActionResult> Execute(RefreshAccessTokenRequest request)
        {
            if(request == null || string.IsNullOrWhiteSpace(request.AccessToken) || string.IsNullOrWhiteSpace(request.RefreshToken)) throw new Exception(ApiMessages.InvalidRequest);

            var result = _accessTokenService.GetValidationResult(request.AccessToken);

            if (!result.IsValid)
            {
                return LoginRequiredResponse();
            }

            if (result.IsExpired)
            {
                return await RefreshTokenResponse(request.RefreshToken, result.UniqueId);
            }

            return CurrentTokensResponse(request.AccessToken, request.RefreshToken);
        }
        private ActionResult LoginRequiredResponse()
        {
            return ActionResult.Ok(new RefreshAccessTokenResponse
            {
                IsLoginRequired = true
            });
        }

        private ActionResult CurrentTokensResponse(string accessToken, string refreshToken)
        {
            return ActionResult.Ok(new RefreshAccessTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        private async Task<ActionResult> RefreshTokenResponse(string refreshToken, string uniqueId)
        {
            var updatedRefreshToken = await _refreshTokenService.GetUpdatedRefreshToken(refreshToken, uniqueId);

            if (updatedRefreshToken == null) return LoginRequiredResponse();

            var newAccessToken = _accessTokenService.GenerateAccessToken(uniqueId);

            return ActionResult.Ok(new RefreshAccessTokenResponse
            {
                RefreshToken = updatedRefreshToken.Token,
                AccessToken = newAccessToken
            });
        }

        
    }
}
