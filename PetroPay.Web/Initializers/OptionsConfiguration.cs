using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetroPay.Web.Configuration.Constants;
using PetroPay.Web.Configuration.Models;

namespace PetroPay.Web.Initializers
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            /*services.Configure<BCryptOptions>(configuration.GetSection(SettingsKeys.BCrypt));*/
            services.Configure<SmtpOptions>(configuration.GetSection(SettingsKeys.Smtp));

            return services;
        }
    }
}
