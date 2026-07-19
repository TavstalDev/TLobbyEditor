// ReSharper disable ClassNeverInstantiated.Global

using YamlDotNet.Serialization;

namespace Tavstal.TLobbyEditor.Models
{
    /// <summary>
    /// Configuration for customizing server data entries (workshop, config, plugins, gamemode) shown in the server browser.
    /// </summary>
    public class CustomDataConfig
    {
        /// <summary>
        /// Gets or sets whether to replace the workshop tag with custom values.
        /// </summary>
        [YamlMember(Order = 0, Description = "Replaces the workshop tag with a custom value")]
        public bool MessWorkshop { get; set; }
        
        /// <summary>
        /// Gets or sets the custom workshop tag values shown in the server browser.
        /// </summary>
        [YamlMember(Order = 1, Description = "Custom workshop tag value shown in the server browser")] 
        public string[] Workshop { get; set; }
        
        /// <summary>
        /// Gets or sets whether to replace config entries with custom values.
        /// </summary>
        [YamlMember(Order = 2, Description = "Replaces config entries with custom values")]
        public bool MessConfig { get; set; }
        
        /// <summary>
        /// Gets or sets the custom config key-value pairs (format: Key=Value).
        /// </summary>
        [YamlMember(Order = 3, Description = "Custom config key-value pairs (format: Key=Value)")]
        public string[] Config { get; set; }
        
        /// <summary>
        /// Gets or sets whether to replace plugin names with custom values.
        /// </summary>
        [YamlMember(Order = 4, Description = "Replaces plugin names with custom values")]
        public bool MessPlugins { get; set; }
        
        /// <summary>
        /// Gets or sets the custom plugin names shown in the server browser.
        /// </summary>
        [YamlMember(Order = 5, Description = "Custom plugin names shown in the server browser")]
        public string[] Plugins { get; set; }
        
        /// <summary>
        /// Gets or sets whether to replace the gamemode name with a custom value.
        /// </summary>
        [YamlMember(Order = 5, Description = "Replaces the gamemode name with a custom value")]
        public bool MessGamemode { get; set; }
        
        /// <summary>
        /// Gets or sets the custom gamemode name shown in the server browser.
        /// </summary>
        [YamlMember(Order = 6, Description = "Custom gamemode name shown in the server browser")]
        public string Gamemode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDataConfig"/> class with default values.
        /// </summary>
        public CustomDataConfig()
        {
            MessWorkshop = true;
            Workshop = new[] { "2563994234" };
            MessConfig = true;
            Config = new[] { "Server.maintenance=false", "Server.version=1.0.0", "Server.alphaonly=false", "Server.betaonly=false" };
            MessPlugins = true;
            Plugins = new[] { "Server configured by", "TLobbyEditor" };
            MessGamemode = true;
            Gamemode = "Conquest";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDataConfig"/> class with specified values.
        /// </summary>
        public CustomDataConfig(bool messWorkshop, string[] workshop, bool messConfig, string[] config, bool messPlugins, string[] plugins, bool messGamemode, string gamemode)
        {
            MessWorkshop = messWorkshop;
            Workshop = workshop;
            MessConfig = messConfig;
            Config = config;
            MessPlugins = messPlugins;
            Plugins = plugins;
            MessGamemode = messGamemode;
            Gamemode = gamemode;
        }
    }
}