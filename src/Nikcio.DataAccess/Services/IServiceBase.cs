using Microsoft.EntityFrameworkCore;
using Nikcio.DataAccess.Repositories;
using Nikcio.DataAccess.UnitOfWorks;

namespace Nikcio.DataAccess.Services {
    /// <summary>
    /// A base for a service
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    public interface IServiceBase<TRepository>
        where TRepository : IDbRepositoryBase<DbContext> {
    }
}
