using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.DataAccess.Settings.Extentions {
    /// <summary>
    /// Extentions
    /// </summary>
    public static class SettingsExtentions {
        /// <summary>
        /// Adds the data access settings
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="configurationSection"></param>
        /// <returns></returns>
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration, string configurationSection) {
            var dataAccessSettings = new DataAccessSettings();
            configuration.Bind(configurationSection, dataAccessSettings);
            services
                .AddSingleton<DataAccessSettings>();

            return services;
        }
    }
}
