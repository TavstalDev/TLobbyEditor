using YamlDotNet.Serialization;

namespace Tavstal.TLobbyEditor.Models
{
    /// <summary>
    /// Represents the configuration for reserving player slots on the server.
    /// </summary>
    public class ReservedSlots
    {
        /// <summary>
        /// Gets or sets whether the reserved slots system is enabled.
        /// </summary>
        [YamlMember(Order = 0, Description = "Enables the reserved slots system")]
        public bool Enable { get; set; }

        /// <summary>
        /// Gets or sets whether players must have a specific permission to join when reserved slots are in use.
        /// </summary>
        [YamlMember(Order = 1, Description = "Requires players to have a permission to join when slots are reserved")]
        public bool RequirePermission { get; set; }

        /// <summary>
        /// Gets or sets the permission string that players need to access reserved slots.
        /// </summary>
        [YamlMember(Order = 2, Description = "Permission required for players to join reserved slots")]
        public string Permission { get; set; }

        /// <summary>
        /// Gets or sets the number of publicly available player slots.
        /// </summary>
        [YamlMember(Order = 3, Description = "Number of public player slots available")]
        public int DefaultSlots { get; set; }

        /// <summary>
        /// Gets or sets the number of extra slots reserved for players with the required permission.
        /// </summary>
        [YamlMember(Order = 4, Description = "Number of extra slots reserved for permitted players")]
        public int MaxReservedSlots { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservedSlots"/> class with default values.
        /// </summary>
        public ReservedSlots()
        {
            Enable = true;
            RequirePermission = true;
            Permission = "reservedslots.active";
            DefaultSlots = 40;
            MaxReservedSlots = 8;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservedSlots"/> class with the specified values.
        /// </summary>
        /// <param name="enable">Whether the reserved slots system is enabled.</param>
        /// <param name="requirePermission">Whether players need a permission to join reserved slots.</param>
        /// <param name="permission">The permission string required to access reserved slots.</param>
        /// <param name="defaultSlots">The number of publicly available player slots.</param>
        /// <param name="maxReservedSlots">The number of extra slots reserved for permitted players.</param>
        public ReservedSlots(bool enable, bool requirePermission, string permission, int defaultSlots, int maxReservedSlots)
        {
            Enable = enable;
            RequirePermission = requirePermission;
            Permission = permission;
            DefaultSlots = defaultSlots;
            MaxReservedSlots = maxReservedSlots;
        }
    }
}
