﻿using Microsoft.Extensions.Configuration;
using Nikcio.DataAccess.Settings.Extensions.Options;

namespace Nikcio.DataAccess.Extensions.Options {
    /// <summary>
    /// Options for the data access package
    /// </summary>
    public class DataAccessOptions {
        /// <summary>
        /// Options for the settings
        /// </summary>
        public virtual SettingsOptions SettingsOptions { get; set; }

        /// <inheritdoc/>
        public DataAccessOptions(IConfiguration configuration) {
            SettingsOptions = new(configuration);
        }
    }
}
