using System.Collections.Generic;

namespace Iot.Models
{
    /// <summary>
    /// Class Category.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
            Downloads = new List<Download>();
        }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        public int CategoryId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the downloads.
        /// </summary>
        /// <value>The downloads.</value>
        public List<Download> Downloads { get; set; }
    }
}