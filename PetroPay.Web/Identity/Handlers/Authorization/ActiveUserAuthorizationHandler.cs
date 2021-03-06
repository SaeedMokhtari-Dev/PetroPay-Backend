using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Identity.Handlers.Authorization
{
    public class ActiveUserAuthorizationHandler : AuthorizationHandler<ActiveUserPolicyRequirement>
    {
        private readonly UserContext _userContext;

        public ActiveUserAuthorizationHandler(UserContext userContext)
        {
            _userContext = userContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ActiveUserPolicyRequirement requirement)
        {
            if (_userContext.IsAuthenticated && _userContext.IsActive)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
