using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Nikcio.DataAccess.Repositories;

namespace Nikcio.DataAccess.UnitOfWorks {
    /// <inheritdoc/>
    public class UnitOfWork<TRepository> : IUnitOfWork<TRepository>
        where TRepository : IDbRepositoryBase<DbContext> {
        private readonly DbContext _context;
        private IDbContextTransaction? _transaction;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repository"></param>
        public UnitOfWork(TRepository repository) {
            _context = repository.GetDBContext();
        }

        /// <inheritdoc/>
        public async Task BeginUnitOfWorkAsync(IsolationLevel IsolationLevel) {
            _transaction = await _context.Database.BeginTransactionAsync(IsolationLevel);
        }

        /// <inheritdoc/>
        public Task BeginUnitOfWorkAsync() {
            return BeginUnitOfWorkAsync(IsolationLevel.Serializable);
        }

        /// <inheritdoc/>
        public async Task CommitUnitOfWorkAsync() {
            if (_transaction != null) {
                try {
                    _context.SaveChanges();
                    await _transaction.CommitAsync();
                } catch (Exception) {
                    await _transaction.RollbackAsync();
                    throw;
                }
            } else {
                throw new ArgumentNullException("_transtaction", "_transtaction cannot be null");
            }
        }
    }
}
