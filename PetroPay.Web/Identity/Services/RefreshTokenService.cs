using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLog;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Interfaces;
using PetroPay.DataAccess.Contexts;
using PetroPay.DataAccess.Entities;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Identity.Services
{
   public class RefreshTokenService: IScoped
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private readonly PetroPayContext _context;

        public RefreshTokenService(PetroPayContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> GenerateRefreshToken(string uniqueId)
        {
            var token = new RefreshToken
            {
                UniqueId = uniqueId,
                Token = GetRefreshTokenString(),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.Add(IdentitySettings.RefreshTokenExpireTime),
                IsActive = true
            };

            await SaveToken(token);

            return token;
        }

        private string GetRefreshTokenString()
        {
            return Guid.NewGuid().ToString();
        }

        public async Task SaveToken(RefreshToken token)
        {
            try
            {
                _context.Entry(token).State = EntityState.Added;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                throw;
            }
        }

        public async Task<RefreshToken> GetUpdatedRefreshToken(string tokenStr, string uniqueId)
        {
            try
            {
                var token = await _context.RefreshTokens
                    .FirstOrDefaultAsync(x => x.UniqueId == uniqueId && x.IsActive && x.Token == tokenStr);

                if (token == null) return null;

                if (token.ExpiresAt < DateTime.UtcNow)
                {
                    token.IsActive = false;

                    await _context.SaveChangesAsync();

                    return null;
                }
                else
                {
                    UpdateTokenExpiration(token);

                    return token;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public async Task<ActionResult> DeactivateToken(string tokenStr, string uniqueId)
        {
            try
            {
                var token = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.UniqueId == uniqueId && x.IsActive && x.Token == tokenStr);

                if (token != null)
                {
                    token.IsActive = false;

                    await _context.SaveChangesAsync();
                }

                return ActionResult.Ok();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ActionResult.Error();
            }
        }

        private void UpdateTokenExpiration(RefreshToken token)
        {
            try
            {
                token.ExpiresAt = DateTime.UtcNow.Add(IdentitySettings.RefreshTokenExpireTime);

                var entry = _context.RefreshTokens.Attach(token);

                entry.Property(x => x.ExpiresAt).IsModified = true;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
