using Microsoft.EntityFrameworkCore;
using Nikcio.DataAccess.Contexts.Models;

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
        protected DbRepositoryBase(IDbContext context) {
            _context = context.Context;
        }

        /// <inheritdoc/>
        public virtual DbContext GetDBContext() {
            return _context;
        }
    }
}
