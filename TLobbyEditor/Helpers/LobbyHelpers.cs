using SDG.Unturned;
using System;
using System.Linq;

namespace Tavstal.TLobbyEditor.Helpers
{
    /// <summary>
    /// A static class containing helper methods for working with lobby-related data.
    /// </summary>
    /// <remarks>
    /// This class provides utility methods to retrieve counts related to server workshop files and mode configuration fields.
    /// </remarks>
    public static class LobbyHelpers 
    {
        /// <summary>
        /// Gets the count of workshop items for the server.
        /// </summary>
        /// <returns>
        /// The number of workshop items, calculated based on the server's workshop file IDs.
        /// </returns>
        public static int GetWorkshopCount() =>
            (string.Join(",", Provider.getServerWorkshopFileIDs().Select(x => x.ToString()).ToArray()).Length - 1) / 120 + 1;

        /// <summary>
        /// Gets the count of configuration fields for the mode configuration data.
        /// </summary>
        /// <returns>
        /// The number of configuration fields, calculated based on the mode configuration data.
        /// </returns>
        public static int GetConfigurationCount() =>
            (string.Join(",", typeof(ModeConfigData).GetFields()
            .SelectMany(x => x.FieldType.GetFields().Select(y => y.GetValue(x.GetValue(Provider.modeConfigData))))
            .Select(x => x is bool v ? v ? "T" : "F" : (string.Empty + x)).ToArray()).Length - 1) / 120 + 1;
    }
}
