using System.Collections.Generic;
using YamlDotNet.Serialization;
// ReSharper disable ClassNeverInstantiated.Global

namespace Tavstal.TLobbyEditor.Models
{
    /// <summary>
    /// Configuration for customizing server information displayed in the server browser.
    /// </summary>
    public class InformationalConfig
    {
        /// <summary>
        /// Gets or sets whether to replace the server description with a custom value.
        /// </summary>
        [YamlMember(Order = 1, Description = "Replaces the server description with a custom value")]
        public bool MessDescription { get; set; }
        
        /// <summary>
        /// Gets or sets the short server description shown in the browser tooltip.
        /// </summary>
        [YamlMember(Order = 2, Description = "Short server description shown in the browser tooltip")]
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets whether to replace the browser hint description with a custom value.
        /// </summary>
        [YamlMember(Order = 3, Description = "Replaces the browser hint description with a custom value")]
        public bool MessBrowserDescription { get; set; }
        
        /// <summary>
        /// Gets or sets the hint line shown below the server name in the browser.
        /// </summary>
        [YamlMember(Order = 4, Description = "Hint line shown below the server name in the browser")]
        public string BrowserDescription { get; set; }
        
        /// <summary>
        /// Gets or sets whether to replace the full server description with custom lines.
        /// </summary>
        [YamlMember(Order = 5, Description = "Replaces the full server description with custom lines")]
        public bool MessDescriptionFull { get; set; }

        /// <summary>
        /// Gets or sets the full multi-line server description shown in browser details.
        /// </summary>
        [YamlMember(Order = 6, Description = "Full multi-line server description shown in browser details")]
        public List<string> DescriptionFull { get; set; }
        
        /// <summary>
        /// Gets or sets whether to replace the server links with custom values.
        /// </summary>
        [YamlMember(Order = 7, Description = "Replaces the server links with custom values")]
        public bool MessLinks { get; set; }
        
        /// <summary>
        /// Gets or sets the custom links displayed in the server browser (message and URL pairs).
        /// </summary>
        [YamlMember(Order = 8, Description = "Custom links displayed in the server browser (message and URL pairs)")]
        public List<CustomLink> Links { get; set; }
        
        /// <summary>
        /// Gets or sets whether to replace the browser icon with a custom URL.
        /// </summary>
        [YamlMember(Order = 9, Description = "Replaces the browser icon with a custom URL")]
        public bool MessBrowserIcon { get; set; }
        
        /// <summary>
        /// Gets or sets the custom icon URL displayed in the server browser.
        /// </summary>
        [YamlMember(Order = 10, Description = "Custom icon URL displayed in the server browser")]
        public string BrowserIcon { get; set; }
        
        /// <summary>
        /// Gets or sets whether to replace the thumbnail with a custom URL.
        /// </summary>
        [YamlMember(Order = 11, Description = "Replaces the thumbnail with a custom URL")]
        public bool MessThumbnail { get; set; }
        
        /// <summary>
        /// Gets or sets the custom thumbnail URL displayed in the server browser.
        /// </summary>
        [YamlMember(Order = 12, Description = "Custom thumbnail URL displayed in the server browser")]
        public string Thumbnail { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationalConfig"/> class with default values.
        /// </summary>
        public InformationalConfig()
        {
            MessDescription = true;
            Description = "<color=yellow>Experience a fresh way to play</color>";
            MessBrowserDescription = true;
            BrowserDescription = "<color=yellow>Hosted by: unknown.com</color>";
            MessDescriptionFull = true;
            DescriptionFull = new List<string> { 
                "<color=#00FFFF>Welcome to our server! We offer a unique, curated experience with high-quality mods and a friendly atmosphere.</color> \n",
                "<color=orange>Why join us?</color>", 
                "<color=green>+</color> <color=white>Active and helpful staff</color>", 
                "<color=green>+</color> <color=white>Balanced economy and loot</color>", 
                "<color=green>+</color> <color=white>Regular content updates</color>", 
                "<color=green>+</color> <color=white>Dedicated high-performance servers</color>", 
                "<color=green>+</color> <color=white>Custom quality-of-life plugins</color>", 
                "<color=green>+</color> <color=white>Join our Discord for news and events!</color>"};

            MessLinks = true;
            Links = new List<CustomLink>
            {
                new CustomLink("Example", "google.com")
            };
            
            MessBrowserIcon = true;
            BrowserIcon = "https://i.imgur.com/UPOnfJS.png";
            MessThumbnail = true;
            Thumbnail = "https://i.imgur.com/UPOnfJS.png";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationalConfig"/> class with specified values.
        /// </summary>
        public InformationalConfig(bool messDescription, string description, bool messBrowserDescription, string browserDescription, bool messDescriptionFull, List<string> descriptionFull, 
            bool messLinks, List<CustomLink> links, bool messBrowserIcon, string browserIcon, bool messThumbnail, string thumbnail)
        {
            MessDescription = messDescription;
            Description = description;
            MessBrowserDescription = messBrowserDescription;
            BrowserDescription = browserDescription;
            MessDescriptionFull = messDescriptionFull;
            DescriptionFull = descriptionFull;
            MessLinks = messLinks;
            Links = links;
            MessBrowserIcon = messBrowserIcon;
            BrowserIcon = browserIcon;
            MessThumbnail = messThumbnail;
            Thumbnail = thumbnail;
        }
    }
}