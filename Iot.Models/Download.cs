using System.Collections.Generic;

namespace Iot.Models
{
    /// <summary>
    /// Class Download.
    /// </summary>
    public class Download
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Download" /> class.
        /// </summary>
        public Download()
        {
            Categories = new List<Category>();
        }

        /// <summary>
        /// Gets or sets the download identifier.
        /// </summary>
        /// <value>The download identifier.</value>
        public int DownloadId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description{ get; set; }
        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string ImageUrl{ get; set; }
        /// <summary>
        /// Gets or sets the type of the download.
        /// </summary>
        /// <value>The type of the download.</value>
        public DownloadType DownloadType { get; set; }
        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get; set; }
    }

    /// <summary>
    /// Enum DownloadType
    /// </summary>
    public enum DownloadType
    {
        /// <summary>
        /// The PDF
        /// </summary>
        PDF,
        /// <summary>
        /// The zip
        /// </summary>
        ZIP,
        /// <summary>
        /// The document
        /// </summary>
        DOC
    }
}