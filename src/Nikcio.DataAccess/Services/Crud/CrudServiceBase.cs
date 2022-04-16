using System.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nikcio.DataAccess.Models;
using Nikcio.DataAccess.Repositories;
using Nikcio.DataAccess.Repositories.Crud;
using Nikcio.DataAccess.Services.Models;
using Nikcio.DataAccess.Settings;
using Nikcio.DataAccess.UnitOfWorks;

namespace Nikcio.DataAccess.Services.Crud {
    /// <inheritdoc/>
    public abstract class CrudServiceBase<TDomain, TRepository> : ServiceBase<TRepository>, ICrudServiceBase<TDomain, TRepository>
        where TDomain : class, IGenericId, new()
        where TRepository : IDbRepositoryBase<DbContext>, IDbCrudRepositoryBase<TDomain> {
        /// <summary>
        /// The repository to excecute the action on
        /// </summary>
        protected readonly TRepository repository;

        /// <summary>
        /// The settings for data access
        /// </summary>
        protected readonly DataAccessSettings dataAccessSettings;

        /// <inheritdoc/>
        protected CrudServiceBase(TRepository repository, ILogger<ServiceBase<TRepository>> logger, DataAccessSettings dataAccessSettings, IUnitOfWork<TRepository> unitOfWork) : base(logger, unitOfWork, repository) {
            this.repository = repository;
            this.dataAccessSettings = dataAccessSettings;
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> Add(TDomain entity, IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await repository.AddAsync(entity);
            }, HttpStatusCode.Created, isolationLevel);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> Add(TDomain entity) {
            return await Add(entity, dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> DeleteById(int id, IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                await repository.DeleteByIdAsync(id);
                return new TDomain();
            }, HttpStatusCode.NoContent, isolationLevel);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> DeleteById(int id) {
            return await DeleteById(id, dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<IEnumerable<TDomain>>> GetAll(IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await repository.GetAllAsync();
            }, HttpStatusCode.OK, isolationLevel);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<IEnumerable<TDomain>>> GetAll() {
            return await GetAll(dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> GetById(int id, IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await repository.GetByIdAsync(id);
            }, HttpStatusCode.OK, isolationLevel);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> GetById(int id) {
            return await GetById(id, dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<IQueryable<TDomain>>> QueryDbSet(IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await repository.QueryDbSet();
            }, HttpStatusCode.OK, isolationLevel);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<IQueryable<TDomain>>> QueryDbSet() {
            return await QueryDbSet(dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> Update(TDomain entity, IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await Task.Run(() => repository.Update(entity));
            }, HttpStatusCode.OK, isolationLevel);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> Update(TDomain entity) {
            return await Update(entity, dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }
    }
}
