using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.DataAccess.Extensions.Options;
using Nikcio.DataAccess.Settings.Extensions;
using Nikcio.DataAccess.UnitOfWorks.Extensions;

namespace Nikcio.DataAccess.Extensions {
    /// <inheritdoc/>
    public static class DataAccessExtensions {
        /// <summary>
        /// Adds services for data access
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration) {
            var options = new DataAccessOptions(configuration);
            return AddDataAccess(services, options);
        }

        /// <summary>
        /// Adds services for data access
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="dataAccessOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration, Action<DataAccessOptions> dataAccessOptions) {
            var options = new DataAccessOptions(configuration);
            dataAccessOptions(options);
            return AddDataAccess(services, options);
        }

        /// <summary>
        /// Adds services for data access
        /// </summary>
        /// <param name="services"></param>
        /// <param name="dataAccessOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccess(this IServiceCollection services, DataAccessOptions dataAccessOptions) {
            services
                .AddSettings(dataAccessOptions.SettingsOptions)
                .AddUnitOfWorks();

            return services;
        }
    }
}
