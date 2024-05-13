using Newtonsoft.Json;
using Tavstal.TLibrary.Compatibility;
using Tavstal.TLobbyEditor.Models;

namespace Tavstal.TLobbyEditor
{
    public class TLobbyEditorConfiguration : ConfigurationBase
    {
        [JsonProperty(Order = 3)]
        public bool ShouldAdversiteServer { get; set; }
        [JsonProperty(Order = 4)]
        public bool HideRocket { get; set; }
        [JsonProperty(Order = 5)]
        public bool HideWorkshop { get; set; }
        [JsonProperty(Order = 6)]
        public bool MessWorkshop { get; set; }
        [JsonProperty(Order = 7)]
        public string[] Workshop { get; set; }
        [JsonProperty(Order = 8)]
        public bool HideConfig { get; set; }
        [JsonProperty(Order = 9)]
        public bool MessConfig { get; set; }
        [JsonProperty(Order = 10)]
        public string[] Config { get; set; }
        [JsonProperty(Order = 11)]
        public bool HidePlugins { get; set; }
        [JsonProperty(Order = 12)]
        public bool MessPlugins { get; set; }
        [JsonProperty(Order = 13)]
        public string[] Plugins { get; set; }
        [JsonProperty(Order = 14)]
        public bool MessGamemode { get; set; }
        [JsonProperty(Order = 15)]
        public string Gamemode { get; set; }
        [JsonProperty(Order = 16)]
        public bool IsPVP { get; set; }
        [JsonProperty(Order = 17)]
        public bool HasCheats { get; set; }
        [JsonProperty(Order = 18)]
        public string Difficulty { get; set; } // EASY, NORMAL, HARD
        [JsonProperty(Order = 19)]
        public string CameraMode { get; set; } // FP, TP, BOTH, VEHICLE 
        [JsonProperty(Order = 20)]
        public bool GoldOnly { get; set; }
        [JsonProperty(Order = 21)]
        public bool HasBattleye { get; set; }
        [JsonProperty(Order = 22)]
        public string Description { get; set; }
        [JsonProperty(Order = 23)]
        public string DescriptionHint { get; set; }
        [JsonProperty(Order = 24)]
        public string[] DescriptionFull { get; set; }
        [JsonProperty(Order = 25)]
        public ReservedSlots ReservedSlots { get; set; }

        public override void LoadDefaults()
        {
            ShouldAdversiteServer = true;
            HideRocket = true;
            HideWorkshop = false;
            MessWorkshop = true;
            Workshop = new string[] { "2563994234" };
            HideConfig = false;
            MessConfig = true;
            Config = new string[] { "Server.maintenance=false", "Server.version=1.0.0", "Server.scorebombactive=false", "Server.alphaonly=false", "Server.betaonly=false" };
            HidePlugins = false;
            MessPlugins = true;
            Plugins = new string[] { "Server configured by", "TLobbyEditor" };
            MessGamemode = true;
            Gamemode = "Conquest";
            IsPVP = true;
            HasCheats = false;
            Difficulty = "EASY";
            CameraMode = "VEHICLE";
            GoldOnly = false;
            HasBattleye = true;
            Description = "<color=yellow>Fight just like soldiers</color>";
            DescriptionHint = "<color=yellow>Hosted by: unknown.com</color>";
            DescriptionFull = new string[] { "<color=#00FFFF>Welcome to Unturfield! Our server is heavily modified by plugins and mods with custom gamemode.</color> \n",
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
