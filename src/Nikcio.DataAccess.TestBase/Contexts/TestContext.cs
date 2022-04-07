using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nikcio.DataAccess.TestBase.Models.Addresses;
using Nikcio.DataAccess.TestBase.Models.Houses;

namespace Nikcio.DataAccess.TestBase.Contexts {
    public class TestContext : DbContext, ITestContext {
        private static readonly string _tablePrefix = "TEST";

        public TestContext(DbContextOptions<TestContext> options) : base(options) {
        }

        public DbSet<House>? Houses { get; set; }
        public DbSet<Address>? Addresses { get; set; }

        public DbContext Context => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Prefix tables
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
                entityType.SetTableName(_tablePrefix + "_" + entityType.GetTableName());
            }
        }
    }
}
