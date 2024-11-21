using Rocket.API;
using System.Collections.Generic;
using System.Reflection;
using Tavstal.TLibrary.Helpers.Unturned;

namespace Tavstal.TLobbyEditor.Commands
{
    public class CommandVersion : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public string Name => ("v" + Assembly.GetExecutingAssembly().GetName().Name);
        public string Help => "Gets the version of the plugin";
        public string Syntax => "";
        public List<string> Aliases => new List<string>();
        public List<string> Permissions => new List<string> { "tshop.version" };


        public void Execute(IRocketPlayer caller, string[] command)
        {
            TLobbyEditor.Instance.SendPlainCommandReply(caller, "#########################################");
            TLobbyEditor.Instance.SendPlainCommandReply(caller, $"# Build Version: {TLobbyEditor.Version}");
            TLobbyEditor.Instance.SendPlainCommandReply(caller, $"# Build Date: {TLobbyEditor.BuildDate}");
            TLobbyEditor.Instance.SendPlainCommandReply(caller, "#########################################");
        }
    }
}
