using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nikcio.DataAccess.Repositories.Crud;
using Nikcio.DataAccess.Repositories;
using Nikcio.DataAccess.Models;
using Nikcio.DataAccess.Services.Models;
using System.Linq;
using Nikcio.DataAccess.Settings;

namespace Nikcio.DataAccess.Services.Crud {
    /// <inheritdoc/>
    public abstract class CrudServiceBase<TDomain, TRepository> : ServiceBase<TRepository>, ICrudServiceBase<TDomain, TRepository>
        where TDomain : class, IGenericId, new()
        where TRepository : IDbRepositoryBase, IDbCrudRepositoryBase<TDomain> {
        /// <summary>
        /// The repository to excecute the action on
        /// </summary>
        protected readonly TRepository repository;

        /// <summary>
        /// The settings for data access
        /// </summary>
        protected readonly DataAccessSettings dataAccessSettings;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        protected CrudServiceBase(TRepository repository, ILogger<ServiceBase<TRepository>> logger) : base(repository, logger) {
            this.repository = repository;
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> Add(TDomain entity, IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await repository.AddAsync(entity);
            }, HttpStatusCode.Created, isolationLevel);
        }

        /// <inheritdoc/>
        public async Task<IServiceResponse<TDomain>> Add(TDomain entity) {
            return await Add(entity, dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> DeleteById(int id, IsolationLevel isolationLevel) {
            return await ExecuteServiceTask<TDomain>(async () => {
                await repository.DeleteByIdAsync(id);
                return null;
            }, HttpStatusCode.NoContent, isolationLevel);
        }

        /// <inheritdoc/>
        public async Task<IServiceResponse<TDomain>> DeleteById(int id) {
            return await DeleteById(id, dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<IEnumerable<TDomain>>> GetAll(IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await repository.GetAllAsync();
            }, HttpStatusCode.OK, isolationLevel);
        }

        /// <inheritdoc/>
        public async Task<IServiceResponse<IEnumerable<TDomain>>> GetAll() {
            return await GetAll(dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> GetById(int id, IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await repository.GetByIdAsync(id);
            }, HttpStatusCode.OK, isolationLevel);
        }

        /// <inheritdoc/>
        public async Task<IServiceResponse<TDomain>> GetById(int id) {
            return await GetById(id, dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<IQueryable<TDomain>>> QueryDbSet(IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await repository.QueryDbSet();
            }, HttpStatusCode.OK, isolationLevel);
        }

        /// <inheritdoc/>
        public async Task<IServiceResponse<IQueryable<TDomain>>> QueryDbSet() {
            return await QueryDbSet(dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual async Task<IServiceResponse<TDomain>> Update(TDomain entity, IsolationLevel isolationLevel) {
            return await ExecuteServiceTask(async () => {
                return await Task.Run(() => repository.Update(entity));
            }, HttpStatusCode.OK, isolationLevel);
        }

        /// <inheritdoc/>
        public async Task<IServiceResponse<TDomain>> Update(TDomain entity) {
            return await Update(entity, dataAccessSettings.DefaultIsolationLevel).ConfigureAwait(false);
        }
    }
}
