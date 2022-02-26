using System.Data;
using Nikcio.DataAccess.Services.Models;

namespace Nikcio.DataAccess.Services.Crud {
    /// <summary>
    /// A basic crud service
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    public interface ICrudService<TDomain>
        where TDomain : class {
        /// <summary>
        /// Queries the dbset
        /// </summary>
        /// <returns></returns>
        Task<IServiceResponse<IQueryable<TDomain>>> QueryDbSet();

        /// <summary>
        /// Gets all entities from the database
        /// </summary>
        /// <returns></returns>
        Task<IServiceResponse<IEnumerable<TDomain>>> GetAll();

        /// <summary>
        /// Gets an entity by an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IServiceResponse<TDomain>> GetById(int id);

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IServiceResponse<TDomain>> DeleteById(int id);

        /// <summary>
        /// Updates a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IServiceResponse<TDomain>> Update(TDomain entity);

        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IServiceResponse<TDomain>> Add(TDomain entity);
        /// <summary>
        /// Queries the dbset
        /// </summary>
        /// <param name="isolationLevel">The isolation level to use</param>
        /// <returns></returns>
        Task<IServiceResponse<IQueryable<TDomain>>> QueryDbSet(IsolationLevel isolationLevel);

        /// <summary>
        /// Gets all entities from the database
        /// </summary>
        /// <param name="isolationLevel">The isolation level to use</param>
        /// <returns></returns>
        Task<IServiceResponse<IEnumerable<TDomain>>> GetAll(IsolationLevel isolationLevel);

        /// <summary>
        /// Gets an entity by an id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isolationLevel">The isolation level to use</param>
        /// <returns></returns>
        Task<IServiceResponse<TDomain>> GetById(int id, IsolationLevel isolationLevel);

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isolationLevel">The isolation level to use</param>
        /// <returns></returns>
        Task<IServiceResponse<TDomain>> DeleteById(int id, IsolationLevel isolationLevel);

        /// <summary>
        /// Updates a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isolationLevel">The isolation level to use</param>
        /// <returns></returns>
        Task<IServiceResponse<TDomain>> Update(TDomain entity, IsolationLevel isolationLevel);

        /// <summary>
        /// Adds an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isolationLevel">The isolation level to use</param>
        /// <returns></returns>
        Task<IServiceResponse<TDomain>> Add(TDomain entity, IsolationLevel isolationLevel);
    }
}