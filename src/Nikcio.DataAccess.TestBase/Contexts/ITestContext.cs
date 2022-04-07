using Microsoft.EntityFrameworkCore;
using Nikcio.DataAccess.Contexts.Models;
using Nikcio.DataAccess.TestBase.Models.Addresses;
using Nikcio.DataAccess.TestBase.Models.Houses;

namespace Nikcio.DataAccess.TestBase.Contexts {
    public interface ITestContext : IDbContext {
        DbSet<House>? Houses { get; set; }
        DbSet<Address>? Addresses { get; set; }
    }
}