using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.DataAccess.Settings.Extentions;

namespace Nikcio.DataAccess.Extentions {
    /// <summary>
    /// Extentions
    /// </summary>
    public static class DataAccessExtentions {
        /// <summary>
        /// Adds services for data access
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration) {
            return AddDataAccess(services, configuration, "Nikcio.DataAccess");
        }

        /// <summary>
        /// Adds services for data access
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="configurationSection"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration, string configurationSection) {
            services
                .AddSettings(configuration, configurationSection);

            return services;
        }
    }
}
