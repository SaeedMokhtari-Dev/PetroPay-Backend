using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NLog;
using PetroPay.Core.Constants;
using PetroPay.Web.Identity.Models;
using TokenOptions = PetroPay.Web.Identity.Models.TokenOptions;

namespace PetroPay.Web.Identity.Services
{
    public class AccessTokenService
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private readonly TokenOptions _options;

        public AccessTokenService(TokenOptions options)
        {
            _options = options;
        }

        public string GenerateAccessToken(string uniqueId)
        {
            var date = DateTime.UtcNow;

            var tokeOptions = new JwtSecurityToken
            (
                issuer: _options.Issuer,
                audience: _options.Audience,
                expires: date.Add(_options.AccessTokenExpireTime),
                signingCredentials: new SigningCredentials(_options.SecurityKey, SecurityAlgorithms.HmacSha512),
                claims: GenerateClaims(uniqueId, date)
            );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        private List<Claim> GenerateClaims(string uniqueId, DateTime date)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, uniqueId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(date).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            };

            return claims;
        }

        public AccessTokenValidationResult GetValidationResult(string accessToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();

                handler.ValidateToken(accessToken, _options.RefreshAccessTokenValidationParameters, out SecurityToken securityToken);

                var identifier = GetTokenSubjectIdentifier((JwtSecurityToken)securityToken);

                if (IsSecurityTokenExpired(securityToken))
                {
                    return AccessTokenValidationResult.Expired(identifier);
                }
                else
                {
                    return AccessTokenValidationResult.Valid(identifier);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                return AccessTokenValidationResult.Invalid();
            }
        }

        public bool IsSecurityTokenExpired(SecurityToken token)
        {
            return token.ValidTo < DateTime.UtcNow;
        }

        private string GetTokenSubjectIdentifier(JwtSecurityToken token)
        {
            var idStr = token.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;

            if(string.IsNullOrWhiteSpace(idStr))
                throw new Exception(ApiMessages.Forbidden);

            return idStr;
        }
    }
}
