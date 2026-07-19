using YamlDotNet.Serialization;
// ReSharper disable ClassNeverInstantiated.Global

namespace Tavstal.TLobbyEditor.Models
{
    /// <summary>
    /// Configuration for server identity properties shown in the server browser.
    /// </summary>
    public class IdentityConfig
    {
        /// <summary>
        /// Gets or sets whether the server appears in the server browser.
        /// </summary>
        [YamlMember(Order = 0, Description = "Whether the server shows up in the server browser")]
        public bool ShouldAdvertiseServer { get; set; }
        
        /// <summary>
        /// Gets or sets whether the server is PVP (false for PVE).
        /// </summary>
        [YamlMember(Order = 1, Description = "Marks the server as PVP (false for PVE)")]
        public bool IsPvp { get; set; }
        
        /// <summary>
        /// Gets or sets whether cheats are enabled on the server.
        /// </summary>
        [YamlMember(Order = 2, Description = "Indicates whether cheats are enabled on the server")]
        public bool HasCheats { get; set; }
        
        /// <summary>
        /// Gets or sets whether BattlEye anti-cheat is active.
        /// </summary>
        [YamlMember(Order = 3, Description = "Indicates whether BattlEye anti-cheat is active")]
        public bool HasBattleEye { get; set; }
        
        /// <summary>
        /// Gets or sets whether the server is Gold-only (false for free-to-play).
        /// </summary>
        [YamlMember(Order = 4, Description = "Marks the server as Gold-only (false for free-to-play)")]
        public bool GoldOnly { get; set; }
        
        /// <summary>
        /// Gets or sets the server difficulty shown in the server browser.
        /// </summary>
        [YamlMember(Order = 5, Description = "Server difficulty shown in the server browser")] 
        public string Difficulty { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the camera mode displayed in the server browser.
        /// </summary>
        [YamlMember(Order = 6, Description = "Camera mode displayed in the server browser")] 
        public string CameraMode { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityConfig"/> class with default values.
        /// </summary>
        public IdentityConfig()
        {
            ShouldAdvertiseServer = true;
            IsPvp = true;
            HasCheats = false;
            HasBattleEye = true;
            GoldOnly = false;
            Difficulty = "EASY";
            CameraMode = "VEHICLE";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityConfig"/> class with specified values.
        /// </summary>
        public IdentityConfig(bool shouldAdvertiseServer, bool isPvp, bool hasCheats, bool hasBattleEye, bool goldOnly)
        {
            ShouldAdvertiseServer = shouldAdvertiseServer;
            IsPvp = isPvp;
            HasCheats = hasCheats;
            HasBattleEye = hasBattleEye;
            GoldOnly = goldOnly;
        }
    }
}