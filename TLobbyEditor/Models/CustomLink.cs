using YamlDotNet.Serialization;

namespace Tavstal.TLobbyEditor.Models
{
    /// <summary>
    /// Represents a custom link displayed in the server browser.
    /// </summary>
    public class CustomLink
    {
        /// <summary>
        /// Gets or sets the display text for the link.
        /// </summary>
        [YamlMember(Order = 0)]
        public string Message { get; set; }
        
        /// <summary>
        /// Gets or sets the URL the link points to.
        /// </summary>
        [YamlMember(Order = 1)]
        public string Url { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLink"/> class with empty values.
        /// </summary>
        public CustomLink()
        {
            Message = string.Empty;
            Url = string.Empty;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLink"/> class with specified values.
        /// </summary>
        public CustomLink(string message, string url)
        {
            Message = message;
            Url = url;
        }
    }
}