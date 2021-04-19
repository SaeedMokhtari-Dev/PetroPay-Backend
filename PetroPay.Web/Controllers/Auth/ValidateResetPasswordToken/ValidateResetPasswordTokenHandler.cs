using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PetroPay.Core.Api.Handlers;
using PetroPay.Core.Api.Models;
using PetroPay.Core.Constants;
using PetroPay.DataAccess.Contexts;

namespace PetroPay.Web.Controllers.Auth.ValidateResetPasswordToken
{
    public class ValidateResetPasswordTokenHandler : ApiRequestHandler<ValidateResetPasswordTokenRequest>
    {
        private readonly PetroPayContext _context;
        private readonly IConfiguration _configuration;

        public ValidateResetPasswordTokenHandler(
            PetroPayContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        protected override async Task<ActionResult> Execute(ValidateResetPasswordTokenRequest request)
        {
            if(!Guid.TryParse(request.Token, out var token))
                return ActionResult.Error(ApiMessages.Auth.ValidateResetPasswordTokenInvalidToken);
            
            /*var passwordResetToken = await context.PasswordResetTokens.Include(w => w.User).SingleOrDefaultAsync(w => w.Token == token);

            if(passwordResetToken == null) return ActionResult.Error(ApiMessages.Auth.ValidateResetPasswordTokenInvalidToken);

            if (passwordResetToken.User.IsAccountActivated == false)
            {
                int activationAccountExpirationHour = configuration.GetValue<int>("ActivationAccountExpirationHour");
                if(passwordResetToken.ResetRequestDate.AddHours(activationAccountExpirationHour) <= DateTime.UtcNow)
                    return ActionResult.Error(ApiMessages.Auth.ValidateResetPasswordTokenInvalidToken);
            }
            else
            {
                int resetPasswordExpirationHour = configuration.GetValue<int>("ResetPasswordExpirationHour");
                if(passwordResetToken.ResetRequestDate.AddHours(resetPasswordExpirationHour) <= DateTime.UtcNow)
                    return ActionResult.Error(ApiMessages.Auth.ValidateResetPasswordTokenInvalidToken);    
            }
            return ActionResult.Ok(ApiMessages.Auth.ValidateResetPasswordTokenValidToken);*/
            return ActionResult.Ok();
            
        }
    }
}
