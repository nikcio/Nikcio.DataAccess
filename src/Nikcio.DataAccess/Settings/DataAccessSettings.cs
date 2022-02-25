using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.DataAccess.Settings {
    /// <summary>
    /// Settings avalible for data access
    /// </summary>
    public class DataAccessSettings {
        /// <summary>
        /// The default isolation level of generic methods
        /// </summary>
        public IsolationLevel DefaultIsolationLevel { get; set; } = IsolationLevel.Serializable;
    }
}
