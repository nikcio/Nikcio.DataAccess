using Microsoft.EntityFrameworkCore;

namespace Nikcio.DataAccess.Repositories {
    /// <summary>
    /// A base for a database repository
    /// </summary>
    public interface IDbRepositoryBase<TDbContext>
        where TDbContext : DbContext {
        /// <summary>
        /// Gets the db context
        /// </summary>
        /// <returns></returns>
        TDbContext GetDBContext();
    }
}