using Nikcio.DataAccess.Models;
using Nikcio.DataAccess.Repositories;
using Nikcio.DataAccess.Repositories.Crud;

namespace Nikcio.DataAccess.Services.Crud {
    /// <summary>
    /// A base for a crud service
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public interface ICrudServiceBase<TDomain, TRepository> : IServiceBase<TRepository>, ICrudService<TDomain>
        where TDomain : class, IGenericId, new()
        where TRepository : IDbRepositoryBase, IDbCrudRepositoryBase<TDomain> {
    }
}
