using Microsoft.EntityFrameworkCore;

namespace Nikcio.DataAccess.Repositories {
    /// <summary>
    /// A base for creating a repository
    /// </summary>
    public abstract class DbRepositoryBase<TDbContext> : IDbRepositoryBase<TDbContext>
        where TDbContext : DbContext {
        private TDbContext? _context;
        private readonly IDbContextFactory<TDbContext> _contextFactory;

        /// <inheritdoc/>
        protected DbRepositoryBase(IDbContextFactory<TDbContext> contextFactory) {
            _contextFactory = contextFactory;
        }


        /// <inheritdoc/>
        public virtual TDbContext GetDBContext() {
            if (_context == null) {
                _context = _contextFactory.CreateDbContext();
                if (_context == null) {
                    throw new NullReferenceException("DbContext wasn't created.");
                }
                return _context;
            } else {
                return _context;
            }
        }
    }
}
