using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PetroPay.Core.Providers;

namespace PetroPay.Web.Initializers
{
    public static class MvcConfiguration
    {
        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services
                .AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new AppControllerFeatureProvider());
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
