using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.DataAccess.UnitOfWorks.Extensions {
    /// <inheritdoc/>
    public static class UnitOfWorkExtensions {
        /// <summary>
        /// Adds unit of work services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddUnitOfWorks(this IServiceCollection services) {
            services
                .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            return services;
        }
    }
}
