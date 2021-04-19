using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetroPay.Core.Constants;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Initializers
{
    public static class CorsConfiguration
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedCorsOrigins = configuration.GetSection(SettingsKeys.AllowedCorsOrigins).Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy(Policies.CorsPolicy, p =>
                {
                    p.WithOrigins(allowedCorsOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            return services;
        }
    }
}
