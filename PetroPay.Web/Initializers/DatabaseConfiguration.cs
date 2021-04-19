using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using PetroPay.DataAccess.Contexts;
using PetroPay.Web.Configuration.Constants;

namespace PetroPay.Web.Initializers
{
    public static class DatabaseConfiguration
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //Logger.Info("Configuring the database and running migrations");

            var connectionString = configuration.GetValue<string>(SettingsKeys.ConnectionString);

            services.AddScoped(x => new PetroPayContext(connectionString));

            /*var migrator = new MysqlMigrator<MySqlConnection>(new MigratorOptions(connectionString, typeof(PetroPayContext).Assembly));

            migrator.Migrate();*/

            return services;
        }
    }
}
