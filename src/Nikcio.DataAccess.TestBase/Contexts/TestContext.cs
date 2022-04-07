using Microsoft.EntityFrameworkCore;

namespace Nikcio.DataAccess.TestBase.Contexts {
    public class TestContext : DbContext, ITestContext {
        public DbContext Context => this;
    }
}
