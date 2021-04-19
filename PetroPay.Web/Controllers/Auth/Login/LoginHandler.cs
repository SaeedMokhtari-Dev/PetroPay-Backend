using System;
using System.Linq;
using System.Threading.Tasks;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.Core.Enums;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Identity.Services;

namespace PetroPay.Web.Controllers.Auth.Login
{
    public class LoginHandler : ApiRequestHandler<LoginRequest>
    {
        private readonly PetroPayContext _context;
        private readonly AccessTokenService _accessTokenService;
        private readonly RefreshTokenService _refreshTokenService;

        public LoginHandler(
            PetroPayContext context,
            AccessTokenService accessTokenService,
            RefreshTokenService refreshTokenService)
        {
            _context = context;
            _accessTokenService = accessTokenService;
            _refreshTokenService = refreshTokenService;
        }

        protected override async Task<ActionResult> Execute(LoginRequest request)
        {
            if (request.RoleType == RoleType.Customer)
            {
                var customer = _context.Companies.FirstOrDefault(x =>
                    x.CompanyAdminUserName.ToLower() == request.Username.ToLower()
                    && x.CompanyAdminUserPassword.ToLower() == request.Password.ToLower());
             
                if (customer == null)
                {
                    return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                }

                return await GetLoginResponse($"Customer_{customer.CompanyId}");
            }
            else if(request.RoleType == RoleType.Supplier)
            {
                var supplier = _context.PetroStations.FirstOrDefault(x =>
                    x.StationUserName.ToLower() == request.Username.ToLower()
                    && x.StationPassword.ToLower() == request.Password.ToLower());
             
                if (supplier == null)
                {
                    return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                }

                return await GetLoginResponse($"Supplier_{supplier.StationId}");
            }
            else if(request.RoleType == RoleType.Admin)
            {
                var admin = _context.Emplyees.FirstOrDefault(x =>
                    x.EmplyeeUserName.ToLower() == request.Username.ToLower()
                    && x.EmplyeePassword.ToLower() == request.Password.ToLower());
             
                if (admin == null)
                {
                    return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                }

                return await GetLoginResponse($"Admin_{admin.EmplyeeId}");
            }
            return ActionResult.Error(ApiMessages.ResourceNotFound);
        }

        private async Task<ActionResult> GetLoginResponse(string uniqueId)
        {
            var accessToken = _accessTokenService.GenerateAccessToken(uniqueId);

            var refreshToken = await _refreshTokenService.GenerateRefreshToken(uniqueId);

            var loginResponse = new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };

            return ActionResult.Ok(loginResponse);
        }
    }
}
