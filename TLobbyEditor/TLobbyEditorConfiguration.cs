using Tavstal.TLibrary.Compatibility;
using Tavstal.TLobbyEditor.Models;

namespace Tavstal.TLobbyEditor
{
    public class TLobbyEditorConfiguration : ConfigurationBase
    {
        public bool ShouldAdversiteServer { get; set; }
        public bool HideRocket { get; set; }
        public bool HideWorkshop { get; set; }
        public bool MessWorkshop { get; set; }
        public string[] Workshop { get; set; }
        public bool HideConfig { get; set; }
        public bool MessConfig { get; set; }
        public string[] Config { get; set; }
        public bool HidePlugins { get; set; }
        public bool MessPlugins { get; set; }
        public string[] Plugins { get; set; }
        public bool MessGamemode { get; set; }
        public string Gamemode { get; set; }
        public bool IsPVP { get; set; }
        public bool HasCheats { get; set; }
        public string Difficulty { get; set; } // EASY, NORMAL, HARD
        public string CameraMode { get; set; } // FP, TP, BOTH, VEHICLE 
        public bool GoldOnly { get; set; }
        public bool HasBattleye { get; set; }
        public string Description { get; set; }
        public string DescriptionHint { get; set; }
        public string[] DescriptionFull { get; set; }
        public ReservedSlots reservedSlots { get; set; }

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
            reservedSlots = new ReservedSlots
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
