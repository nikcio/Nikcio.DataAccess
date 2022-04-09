using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nikcio.DataAccess.TestBase.Contexts;

namespace Nikcio.DataAccess.Tests.Bases {
    [TestClass]
    public class ContextTestBase {
        private const string _connectionString = "Server=localhost,55555;Database=TestDatabase;User Id='sa';Password='Fe1tgmd%ff#DJNhGm3yoF6wl%!VI7v'";

        [TestInitialize]
        public async Task PrepareTest() {
            var testContext = CreateContext();
            await testContext.Context.Database.EnsureDeletedAsync();
            await testContext.Context.Database.MigrateAsync();
        }

        protected static ITestContext CreateContext() {
            var options = new DbContextOptionsBuilder<DataAccess.TestBase.Contexts.TestContext>()
                            .UseSqlServer(_connectionString)
                            .Options;
            var testContext = new DataAccess.TestBase.Contexts.TestContext(options);
            return testContext;
        }
    }
}