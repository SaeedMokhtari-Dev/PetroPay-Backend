using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using PetroPay.Web.Identity.Constants;
using PetroPay.Web.Identity.Handlers.Authorization;

namespace PetroPay.Web.Initializers
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options
                    .RequireActiveUser()
                    .DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(AuthSchemes.Jwt)
                    .Build();
            });

            services.AddScoped<IAuthorizationHandler, ActiveUserAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, AdminUserAuthorizationHandler>();

            return services;
        }
    }
}
