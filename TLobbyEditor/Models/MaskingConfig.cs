// ReSharper disable ClassNeverInstantiated.Global

using YamlDotNet.Serialization;

namespace Tavstal.TLobbyEditor.Models
{
    /// <summary>
    /// Configuration for hiding server metadata from the server browser.
    /// </summary>
    public class MaskingConfig
    {
        /// <summary>
        /// Gets or sets whether to hide the Rocket mod loader tag.
        /// </summary>
        [YamlMember(Order = 0, Description = "Hides the Rocket mod loader tag from the server browser")]
        public bool HideRocket { get; set; }
        
        /// <summary>
        /// Gets or sets whether to hide the Steam Workshop tag.
        /// </summary>
        [YamlMember(Order = 1, Description = "Hides workshop tag from the server browser")]
        public bool HideWorkshop { get; set; }
        
        /// <summary>
        /// Gets or sets whether to hide config entries from the server browser.
        /// </summary>
        [YamlMember(Order = 2, Description = "Hides config entries from the server browser")]
        public bool HideConfig { get; set; }
        
        /// <summary>
        /// Gets or sets whether to hide plugin names from the server browser.
        /// </summary>
        [YamlMember(Order = 3, Description = "Hides plugin names from the server browser")]
        public bool HidePlugins { get; set; }

        public MaskingConfig() {}
        
        public MaskingConfig(bool hideRocket, bool hideWorkshop, bool hideConfig, bool hidePlugins)
        {
            HideRocket = hideRocket;
            HideWorkshop = hideWorkshop;
            HideConfig = hideConfig;
            HidePlugins = hidePlugins;
        }
    }
}