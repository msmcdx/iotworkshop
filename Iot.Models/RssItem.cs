using System;

namespace Iot.Models
{
    /// <summary>
    /// Class RssItem.
    /// </summary>
    public class RssItem
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the RSS image.
        /// </summary>
        /// <value>The RSS image.</value>
        public string RssImage { get; set; }
        /// <summary>
        /// Gets or sets the published date.
        /// </summary>
        /// <value>The published date.</value>
        public DateTime PublishedDate { get; set; }
    }
}