using Tavstal.TLibrary.Models.Config;
using Tavstal.TLibrary.Models.Logging;
using Tavstal.TLobbyEditor.Models;
using YamlDotNet.Serialization;
// ReSharper disable ClassNeverInstantiated.Global

namespace Tavstal.TLobbyEditor
{
    public class LobbyEditorConfiguration : YamlConfiguration
    {
        [YamlMember(Order = 3, Description = "\n")]
        public InformationalConfig Informational { get; set; }
        
        [YamlMember(Order = 4, Description = "\n")]
        public IdentityConfig Identity { get; set; }
        
        [YamlMember(Order = 5, Description = "\n")]
        public MaskingConfig Masking { get; set; }

        [YamlMember(Order = 6, Description = "\n")]
        public CustomDataConfig CustomData { get; set; }
        
        [YamlMember(Order = 7, Description = "\n")]
        public ReservedSlots ReservedSlots { get; set; }
        
        public override void LoadDefaults()
        {
            General = new GeneralConfig
            {
                MessageIcon = "https://raw.githubusercontent.com/TavstalDev/TLobbyEditor/refs/heads/master/assets/icon.png"
            };
            Informational = new InformationalConfig();
            Identity = new IdentityConfig();
            Masking = new MaskingConfig();
            CustomData = new CustomDataConfig();
            ReservedSlots = new ReservedSlots();
        }

        public LobbyEditorConfiguration()
        {
            Informational = new InformationalConfig();
            Identity = new IdentityConfig();
            Masking = new MaskingConfig();
            CustomData = new CustomDataConfig();
            ReservedSlots = new ReservedSlots();
        }

        public LobbyEditorConfiguration(string fileName, string path) : base(fileName, path)
        {
            Informational = new InformationalConfig();
            Identity = new IdentityConfig();
            Masking = new MaskingConfig();
            CustomData = new CustomDataConfig();
            ReservedSlots = new ReservedSlots();
        }
    }
}
