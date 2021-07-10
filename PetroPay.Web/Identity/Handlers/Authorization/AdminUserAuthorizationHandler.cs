using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PetroPay.Core.Enums;
using PetroPay.Web.Identity.Contexts;

namespace PetroPay.Web.Identity.Handlers.Authorization
{
    public class AdminUserAuthorizationHandler : AuthorizationHandler<AdminUserPolicyRequirement>
    {
        private readonly UserContext _userContext;

        public AdminUserAuthorizationHandler(UserContext userContext)
        {
            _userContext = userContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminUserPolicyRequirement requirement)
        {
            if (_userContext.IsAuthenticated && _userContext.IsActive && _userContext.Role == RoleType.Admin)
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