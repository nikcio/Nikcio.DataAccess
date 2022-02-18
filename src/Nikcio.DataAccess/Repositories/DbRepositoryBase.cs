using Nikcio.DataAccess.Contexts.Models;
using Microsoft.EntityFrameworkCore;

namespace Nikcio.DataAccess.Repositories {
    /// <summary>
    /// A base for creating a repository
    /// </summary>
    public abstract class DbRepositoryBase : IDbRepositoryBase {
        private readonly DbContext _context;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"></param>
        public DbRepositoryBase(IDbContext context) {
            _context = context.Context;
        }

        /// <inheritdoc/>
        public virtual DbContext GetDBContext() {
            return _context;
        }
    }
}
