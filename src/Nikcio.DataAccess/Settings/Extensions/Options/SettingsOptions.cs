using Microsoft.Extensions.Configuration;

namespace Nikcio.DataAccess.Settings.Extensions.Options {
    /// <summary>
    /// Options for settings
    /// </summary>
    public class SettingsOptions {
        /// <summary>
        /// The app configuration
        /// </summary>
        public virtual IConfiguration Configuration { get; set; }

        /// <summary>
        /// The configruation section to use for the settings
        /// </summary>
        public virtual string ConfigurationSection { get; set; } = "Nikcio:DataAccess";

        /// <inheritdoc/>
        public SettingsOptions(IConfiguration configuration) {
            Configuration = configuration;
        }
    }
}
