using Microsoft.EntityFrameworkCore;

namespace Nikcio.DataAccess.TestBase.Contexts.Extensions {
    public static class ContextExtensions {
        public static IServiceCollection AddContexts(this IServiceCollection services, ContextOptions contextOptions) {
            services.AddPooledDbContextFactory<TestContext>(options =>
                options.UseSqlServer(contextOptions.Configuration.GetConnectionString(contextOptions.ConnectionStringKey)));

            services.AddTransient<ITestContext>(x => {
                var factory = x.GetRequiredService<IDbContextFactory<TestContext>>();
                return factory.CreateDbContext();
            });

            var context = services.BuildServiceProvider().GetRequiredService<ITestContext>();

            return services;
        }
    }

    public class ContextOptions {
        public string ConnectionStringKey { get; set; }
        public IConfiguration Configuration { get; set; }

        public ContextOptions(string connectionStringKey, IConfiguration configuration) {
            ConnectionStringKey = connectionStringKey;
            Configuration = configuration;
        }
    }
}
