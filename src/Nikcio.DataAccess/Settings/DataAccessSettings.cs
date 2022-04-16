using System.Data;

namespace Nikcio.DataAccess.Settings {
    /// <summary>
    /// Settings avalible for data access
    /// </summary>
    public class DataAccessSettings {
        /// <summary>
        /// The default isolation level of generic methods
        /// </summary>
        public virtual IsolationLevel DefaultIsolationLevel { get; set; } = IsolationLevel.Serializable;
    }
}
