using Microsoft.AspNetCore.Authorization;

namespace PetroPay.Web.Identity.Handlers.Authorization
{
    public class AdminUserPolicyRequirement : IAuthorizationRequirement
    {
        public bool IsActive { get; }

        public AdminUserPolicyRequirement(bool isActive)
        {
            IsActive = isActive;
        }
    }
}