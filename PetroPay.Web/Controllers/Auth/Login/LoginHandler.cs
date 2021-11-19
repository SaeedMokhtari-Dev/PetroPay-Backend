using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            switch (request.RoleType)
            {
                case RoleType.Customer:
                {
                    var customer = await _context.Companies.FirstOrDefaultAsync(x =>
                        x.CompanyAdminUserName.ToLower() == request.Username.ToLower()
                        && x.CompanyAdminUserPassword.ToLower() == request.Password.ToLower());
             
                    if (customer == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }

                    return await GetLoginResponse($"Customer_{customer.CompanyId}");
                }
                case RoleType.CustomerBranch:
                {
                    var customerBranch = await _context.CompanyBranches.FirstOrDefaultAsync(x =>
                        x.CompanyBranchAdminUserName.ToLower() == request.Username.ToLower()
                        && x.CompanyBranchAdminUserPassword.ToLower() == request.Password.ToLower());
             
                    if (customerBranch == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }

                    return await GetLoginResponse($"CustomerBranch_{customerBranch.CompanyBranchId}");
                }
                case RoleType.Supplier:
                {
                    var petrolCompany = await _context.PetrolCompanies.FirstOrDefaultAsync(x =>
                        x.PetrolCompanyAdminUserName.ToLower() == request.Username.ToLower()
                        && x.PetrolCompanyAdminUserPassword.ToLower() == request.Password.ToLower());
             
                    if (petrolCompany == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }

                    return await GetLoginResponse($"Supplier_{petrolCompany.PetrolCompanyId}");
                }
                case RoleType.SupplierBranch:
                {
                    var supplier = await _context.PetroStations.FirstOrDefaultAsync(x =>
                        x.StationUserName.ToLower() == request.Username.ToLower()
                        && x.StationPassword.ToLower() == request.Password.ToLower());
             
                    if (supplier == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }

                    return await GetLoginResponse($"SupplierBranch_{supplier.StationId}");
                }
                case RoleType.Admin:
                {
                    var admin = await _context.Emplyees.FirstOrDefaultAsync(x =>
                        x.EmplyeeUserName.ToLower() == request.Username.ToLower()
                        && x.EmplyeePassword.ToLower() == request.Password.ToLower());
             
                    if (admin == null)
                    {
                        return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
                    }

                    return await GetLoginResponse($"Admin_{admin.EmplyeeId}");
                }
                default:
                    return ActionResult.Error(ApiMessages.ResourceNotFound);
            }
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
