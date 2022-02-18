using Microsoft.EntityFrameworkCore;

namespace Nikcio.DataAccess.Repositories {
    /// <summary>
    /// A base for a database repository
    /// </summary>
    public interface IDbRepositoryBase {
        /// <summary>
        /// Gets the db context
        /// </summary>
        /// <returns></returns>
        DbContext GetDBContext();
    }
}