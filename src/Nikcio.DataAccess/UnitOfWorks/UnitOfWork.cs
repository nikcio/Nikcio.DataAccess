﻿using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Nikcio.DataAccess.Repositories;

namespace Nikcio.DataAccess.UnitOfWorks {
    /// <inheritdoc/>
    public class UnitOfWork<TRepository> : IUnitOfWork<TRepository>
        where TRepository : IDbRepositoryBase<DbContext> {
        private DbContext? _context;
        private IDbContextTransaction? _transaction;
        private readonly ILogger<UnitOfWork<TRepository>> _logger;

        /// <inheritdoc/>
        public UnitOfWork(ILogger<UnitOfWork<TRepository>> logger) {
            _logger = logger;
        }

        /// <inheritdoc/>
        public void SetDbContext(TRepository repository) {
            _context = repository.GetDBContext();
        }

        /// <inheritdoc/>
        public async Task BeginUnitOfWorkAsync(IsolationLevel IsolationLevel) {
            if (_transaction != null) {
                var exception = new InvalidOperationException("Cannot open new transaction while current transaction is not closed");
                _logger.LogError(exception, "Cannot open new transaction while current transaction is not closed");
                throw exception;
            } else {
                if (_context == null) {
                    throw new NullReferenceException("DbContext cannot be null");
                }
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
                    if (_context == null) {
                        throw new NullReferenceException("DbContext cannot be null");
                    }
                    _context.SaveChanges();
                    await _transaction.CommitAsync();
                } catch (Exception ex) {
                    _logger.LogError(ex, "Failed to commit transaction");
                    await _transaction.RollbackAsync();
                    throw new DbUpdateException("Failed commiting transaction", ex);
                }
                await _transaction.DisposeAsync();
                _transaction = null;
            } else {
                throw new NullReferenceException("Transtaction cannot be null");
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
