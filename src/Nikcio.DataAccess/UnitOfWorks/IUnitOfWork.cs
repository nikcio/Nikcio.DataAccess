using System.Data;
using Microsoft.EntityFrameworkCore;
using Nikcio.DataAccess.Repositories;

namespace Nikcio.DataAccess.UnitOfWorks {
    /// <summary>
    /// A unit of work
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    public interface IUnitOfWork<TRepository> where TRepository : IDbRepositoryBase<DbContext> {
        /// <summary>
        /// Begins a unit of work opreation
        /// </summary>
        /// <returns></returns>
        Task BeginUnitOfWorkAsync();

        /// <summary>
        /// Begins a unit of work opreation
        /// </summary>
        /// <param name="IsolationLevel"></param>
        /// <returns></returns>
        Task BeginUnitOfWorkAsync(IsolationLevel IsolationLevel);

        /// <summary>
        /// Commits a unit of work opreation
        /// </summary>
        /// <returns></returns>
        Task CommitUnitOfWorkAsync();

        /// <summary>
        /// Closes a unit of work in case of a faulty execution
        /// </summary>
        /// <returns></returns>
        Task CloseUnitOfWorkAsync();

        /// <summary>
        /// Sets the dbContext of the unit of work
        /// </summary>
        /// <param name="repository"></param>
        void SetDbContext(TRepository repository);
    }
}
