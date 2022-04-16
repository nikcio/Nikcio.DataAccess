using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Nikcio.DataAccess.Repositories;

namespace Nikcio.DataAccess.UnitOfWorks {
    /// <inheritdoc/>
    public class UnitOfWork<TRepository> : IUnitOfWork<TRepository>
        where TRepository : IDbRepositoryBase<DbContext> {
        private readonly DbContext _context;
        private IDbContextTransaction? _transaction;
        private readonly ILogger<UnitOfWork<TRepository>> _logger;

        /// <inheritdoc/>
        public UnitOfWork(TRepository repository, ILogger<UnitOfWork<TRepository>> logger) {
            _context = repository.GetDBContext();
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task BeginUnitOfWorkAsync(IsolationLevel IsolationLevel) {
            if (_transaction != null) {
                var exception = new InvalidOperationException("Cannot open new transaction while current transaction is not closed");
                _logger.LogError(exception, "Cannot open new transaction while current transaction is not closed");
                throw exception;
            } else {
                _transaction = await _context.Database.BeginTransactionAsync(IsolationLevel);
            }
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
                } catch (Exception ex) {
                    await _transaction.RollbackAsync();
                    throw new DbUpdateException("Failed commiting transaction", ex);
                }
            } else {
                throw new ArgumentNullException("_transtaction", "_transtaction cannot be null");
            }
        }

        /// <inheritdoc/>
        public async Task CloseUnitOfWorkAsync() {
            if (_transaction != null) {
                try {
                    await _transaction.RollbackAsync();
                } catch (Exception ex) {
                    _logger.LogError(ex, "Failed closing Unit of Work");
                }
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
