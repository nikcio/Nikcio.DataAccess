using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nikcio.DataAccess.Models;

namespace Nikcio.DataAccess.Repositories.Crud {
    /// <inheritdoc/>
    public class DbCrudRepositoryBase<TDomain> : DbRepositoryBase<DbContext>, IDbCrudRepositoryBase<TDomain>
        where TDomain : class, IGenericId, new() {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger<DbCrudRepositoryBase<TDomain>> logger;

        /// <summary>
        /// The repository dbset
        /// </summary>
        protected readonly DbSet<TDomain> dbSet;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="contextFactory"></param>
        /// <param name="logger"></param>
        protected DbCrudRepositoryBase(IDbContextFactory<DbContext> contextFactory, ILogger<DbCrudRepositoryBase<TDomain>> logger) : base(contextFactory) {
            dbSet = GetDBContext().Set<TDomain>();
            this.logger = logger;
        }

        /// <inheritdoc/>
        public virtual async Task<TDomain> AddAsync(TDomain entity) {
            try {
                dbSet.Attach(entity);
                var createdEntity = await dbSet.AddAsync(entity).ConfigureAwait(false);
                return createdEntity.Entity;
            } catch (Exception e) {
                logger.LogError(e, "Failed while adding {TDomain}", typeof(TDomain));
                throw new TaskCanceledException("Task failed", e);
            }
        }

        /// <inheritdoc/>
        public virtual async Task DeleteByIdAsync(int id) {
            try {
                var entity = await GetByIdAsync(id).ConfigureAwait(false);
                if (entity != null) {
                    dbSet.Remove(entity);
                }
            } catch (Exception e) {
                logger.LogError(e, "Failed on Delete with {TDomain}", typeof(TDomain));
                throw new TaskCanceledException("Task failed", e);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TDomain>> GetAllAsync() {
            try {
                return await dbSet.ToListAsync().ConfigureAwait(false);
            } catch (Exception e) {
                logger.LogError(e, "Failed getting all {TDomain}", typeof(TDomain));
                throw new TaskCanceledException("Task failed", e);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<TDomain?> GetByIdAsync(int id) {
            try {
                return await dbSet.FindAsync(id).ConfigureAwait(false);
            } catch (Exception e) {
                logger.LogError(e, "Failed on GetById with {TDomain} with id {Id}", typeof(TDomain), id);
                throw new TaskCanceledException("Task failed", e);
            }
        }

        /// <inheritdoc/>
        public virtual async Task<IQueryable<TDomain>> QueryDbSet() {
            try {
                return await Task.FromResult(dbSet).ConfigureAwait(false);
            } catch (Exception e) {
                logger.LogError(e, "Failed query {TDomain}", typeof(TDomain));
                throw new TaskCanceledException("Task failed", e);
            }
        }

        /// <inheritdoc/>
        public virtual TDomain Update(TDomain entity) {
            try {
                dbSet.Attach(entity);
                var updatedEntity = dbSet.Update(entity);
                return updatedEntity.Entity;
            } catch (Exception e) {
                logger.LogError(e, "Failed on Update with {TDomain}", typeof(TDomain));
                throw new ArgumentException("Failed updating entity", e);
            }
        }

        /// <summary>
        /// Adds a collection of items to a entity
        /// </summary>
        /// <typeparam name="TCollectionItemType"></typeparam>
        /// <param name="id"></param>
        /// <param name="collectionIds"></param>
        /// <param name="collectionKeySelector"></param>
        /// <returns></returns>
        /// <exception cref="TaskCanceledException"></exception>
        protected virtual async Task<TDomain> AddToCollection<TCollectionItemType>(int id, int[] collectionIds, Expression<Func<TDomain, List<TCollectionItemType>>> collectionKeySelector)
            where TCollectionItemType : class, IGenericId, new() {
            try {
                Func<TDomain, List<TCollectionItemType>> compiledCollectionKeySelector = collectionKeySelector.Compile();
                var domain = await dbSet.Include(collectionKeySelector).FirstOrDefaultAsync(item => item.Id == id);
                if (domain == null) {
                    throw new ArgumentException("Id must reference a valid entity", nameof(id));
                }
                var collection = collectionIds.Where(itemId => !compiledCollectionKeySelector(domain).Any(item => item.Id == itemId));
                var loadedCollection = GetDBContext().Set<TCollectionItemType>().Where(item => collection.Any(id => id == item.Id));
                compiledCollectionKeySelector(domain).AddRange(loadedCollection);
                return domain;
            } catch (Exception e) {
                logger.LogError(e, "Failed while adding collection {TCollection} to {TDomain}", typeof(List<TCollectionItemType>), typeof(TDomain));
                throw new TaskCanceledException("Task failed", e);
            }
        }

        /// <summary>
        /// Removes a colection of items from a entity
        /// </summary>
        /// <typeparam name="TCollectionItemType"></typeparam>
        /// <param name="id"></param>
        /// <param name="collectionIds"></param>
        /// <param name="collectionKeySelector"></param>
        /// <returns></returns>
        /// <exception cref="TaskCanceledException"></exception>
        protected virtual async Task<TDomain> RemoveFromCollection<TCollectionItemType>(int id, int[] collectionIds, Expression<Func<TDomain, List<TCollectionItemType>>> collectionKeySelector)
            where TCollectionItemType : class, IGenericId, new() {
            try {
                Func<TDomain, List<TCollectionItemType>> compiledCollectionKeySelector = collectionKeySelector.Compile();
                var domain = await dbSet.Include(collectionKeySelector).FirstOrDefaultAsync(item => item.Id == id);
                var collection = collectionIds.Select(itemId => new TCollectionItemType { Id = itemId });
                if (domain == null) {
                    throw new ArgumentException("Id must reference a valid entity", nameof(id));
                }
                compiledCollectionKeySelector(domain).RemoveAll(collectionItem => collection.Any(c => c.Id == collectionItem.Id));
                return domain;
            } catch (Exception e) {
                logger.LogError(e, "Failed while removing collection {TCollection} from {TDomain}", typeof(List<TCollectionItemType>), typeof(TDomain));
                throw new TaskCanceledException("Task failed", e);
            }
        }
    }
}
