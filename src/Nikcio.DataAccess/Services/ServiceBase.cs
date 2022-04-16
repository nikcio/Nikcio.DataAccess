using System.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nikcio.DataAccess.Repositories;
using Nikcio.DataAccess.Services.Models;
using Nikcio.DataAccess.UnitOfWorks;

namespace Nikcio.DataAccess.Services {
    /// <summary>
    /// A base for a service
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    public abstract class ServiceBase<TRepository> : IServiceBase<TRepository>
        where TRepository : IDbRepositoryBase<DbContext> {
        /// <summary>
        /// The logger
        /// </summary>
        protected ILogger<ServiceBase<TRepository>> Logger { get; }

        /// <summary>
        /// The unit of work
        /// </summary>
        protected IUnitOfWork<TRepository> UnitOfWork { get; }

        /// <inheritdoc/>
        protected ServiceBase(ILogger<ServiceBase<TRepository>> logger, IUnitOfWork<TRepository> unitOfWork) {
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Executes an func that returns a value within a unit of work
        /// </summary>
        /// <typeparam name="TDomain"></typeparam>
        /// <param name="func"></param>
        /// <param name="statusCode"></param>
        /// <param name="IsolationLevel"></param>
        /// <returns></returns>
        protected virtual async Task<IServiceResponse<TDomain>> ExecuteServiceTask<TDomain>(Func<Task<TDomain?>> func, HttpStatusCode statusCode, IsolationLevel IsolationLevel)
            where TDomain : class {
            try {
                await UnitOfWork.BeginUnitOfWorkAsync(IsolationLevel);
                var response = await func.Invoke().ConfigureAwait(false);
                await UnitOfWork.CommitUnitOfWorkAsync();
                return new ServiceResponse<TDomain>(statusCode, response);
            } catch (Exception ex) {
                Logger.LogError(ex, "Task failed with {TDomain}", typeof(TDomain));
                await UnitOfWork.CloseUnitOfWorkAsync();
                return new ServiceResponse<TDomain>(HttpStatusCode.InternalServerError, null);
            }
        }
    }
}
