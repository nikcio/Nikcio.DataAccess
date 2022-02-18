using Microsoft.EntityFrameworkCore;

namespace Nikcio.DataAccess.Contexts.Models {
    /// <summary>
    /// A DbContext
    /// </summary>
    public interface IDbContext {
        /// <summary>
        /// The context
        /// </summary>
        public DbContext Context { get; }
    }
}