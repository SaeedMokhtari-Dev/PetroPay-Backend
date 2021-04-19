using Microsoft.AspNetCore.Authorization;
using PetroPay.Core.Constants;

namespace PetroPay.Web.Identity.Handlers.Authorization
{
    public static class AuthorizationPolicyExtensions
    {
        public static AuthorizationOptions RequireActiveUser(this AuthorizationOptions options)
        {
            options.AddPolicy(nameof(Policies.ActiveUser), x => x.Requirements.Add(new ActiveUserPolicyRequirement(true)));

            return options;
        }
    }
}
