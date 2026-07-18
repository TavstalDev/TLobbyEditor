using System;
using Tavstal.TLibrary.Models.Config;
using Tavstal.TLibrary.Models.Logging;
using Tavstal.TLobbyEditor.Models;
using YamlDotNet.Serialization;
// ReSharper disable ClassNeverInstantiated.Global

namespace Tavstal.TLobbyEditor
{
    public class TLobbyEditorConfiguration : YamlConfiguration
    {
        [YamlMember(Order = 3, Description = "Whether the server shows up in the server browser")]
        public bool ShouldAdvertiseServer { get; set; }
        [YamlMember(Order = 4, Description = "Hides the Rocket mod loader tag from the server browser")]
        public bool HideRocket { get; set; }
        [YamlMember(Order = 5, Description = "Hides workshop tag from the server browser")]
        public bool HideWorkshop { get; set; }
        [YamlMember(Order = 6, Description = "Replaces the workshop tag with a custom value")]
        public bool MessWorkshop { get; set; }
        [YamlMember(Order = 7, Description = "Custom workshop tag value shown in the server browser")] 
        public string[] Workshop { get; set; } = Array.Empty<string>();
        [YamlMember(Order = 8, Description = "Hides config entries from the server browser")]
        public bool HideConfig { get; set; }
        [YamlMember(Order = 9, Description = "Replaces config entries with custom values")]
        public bool MessConfig { get; set; }
        [YamlMember(Order = 10, Description = "Custom config key-value pairs (format: Key=Value)")]
        public string[] Config { get; set; }  = Array.Empty<string>();
        [YamlMember(Order = 11, Description = "Hides plugin names from the server browser")]
        public bool HidePlugins { get; set; }
        [YamlMember(Order = 12, Description = "Replaces plugin names with custom values")]
        public bool MessPlugins { get; set; }
        [YamlMember(Order = 13, Description = "Custom plugin names shown in the server browser")]
        public string[] Plugins { get; set; }  = Array.Empty<string>();
        [YamlMember(Order = 14, Description = "Replaces the gamemode name with a custom value")]
        public bool MessGamemode { get; set; }
        [YamlMember(Order = 15, Description = "Custom gamemode name shown in the server browser")]
        public string Gamemode { get; set; } = string.Empty;
        [YamlMember(Order = 16, Description = "Marks the server as PVP (false for PVE)")]
        public bool IsPVP { get; set; }
        [YamlMember(Order = 17, Description = "Indicates whether cheats are enabled on the server")]
        public bool HasCheats { get; set; }
        [YamlMember(Order = 18, Description = "Server difficulty shown in the server browser")] 
        public string Difficulty { get; set; } = string.Empty;
        [YamlMember(Order = 19, Description = "Camera mode displayed in the server browser")] 
        public string CameraMode { get; set; } = string.Empty;
        [YamlMember(Order = 20, Description = "Marks the server as Gold-only (false for free-to-play)")]
        public bool GoldOnly { get; set; }
        [YamlMember(Order = 21, Description = "Indicates whether BattlEye anti-cheat is active")]
        public bool HasBattleEye { get; set; }
        [YamlMember(Order = 22, Description = "Short server description shown in the browser tooltip")]
        public string Description { get; set; } = string.Empty; 
        [YamlMember(Order = 23, Description = "Hint line shown below the server name in the browser")]
        public string DescriptionHint { get; set; } = string.Empty; 
        [YamlMember(Order = 24, Description = "Full multi-line server description shown in browser details")]
        public string[] DescriptionFull { get; set; }  = Array.Empty<string>();
        [YamlMember(Order = 25, Description = "Configuration for reserving player slots")]
        public ReservedSlots ReservedSlots { get; set; } = new  ReservedSlots();

        public override void LoadDefaults()
        {
            Locale = "en";
            LogLevel = ELogLevel.INFO;
            DownloadLocalePacks = true;
            ShouldAdvertiseServer = true;
            HideRocket = true;
            HideWorkshop = false;
            MessWorkshop = true;
            Workshop = new[] { "2563994234" };
            HideConfig = false;
            MessConfig = true;
            Config = new[] { "Server.maintenance=false", "Server.version=1.0.0", "Server.scorebombactive=false", "Server.alphaonly=false", "Server.betaonly=false" };
            HidePlugins = false;
            MessPlugins = true;
            Plugins = new[] { "Server configured by", "TLobbyEditor" };
            MessGamemode = true;
            Gamemode = "Conquest";
            IsPVP = true;
            HasCheats = false;
            Difficulty = "EASY";
            CameraMode = "VEHICLE";
            GoldOnly = false;
            HasBattleEye = true;
            Description = "<color=yellow>Fight just like soldiers</color>";
            DescriptionHint = "<color=yellow>Hosted by: unknown.com</color>";
            DescriptionFull = new[] { "<color=#00FFFF>Welcome to Unturfield! Our server is heavily modified by plugins and mods with custom gamemode.</color> \n",
                "<color=orange>Features</color>", "<color=green>+</color> <color=white>Conquest gamemode</color>", "<color=green>+</color> <color=white>0/24 online</color>", "<color=green>+</color> <color=white>Objectives</color>",
                "<color=green>+</color> <color=white>Teams</color>", "<color=green>+</color> <color=white>Loadouts</color>", "<color=green>+</color> <color=white>Revive System</color>", "<color=green>+</color> <color=white>Custom HUD</color>",
                "<color=green>+</color> <color=white>Much more!</color>"};
            ReservedSlots = new ReservedSlots
            {
                Enable = true,
                RequirePermission = true,
                Permission = "reservedslots.active",
                DefaultSlots = 40,
                MaxReservedSlots = 8, 
            };
        }
    }
}
