namespace Iot.Models
{
    /// <summary>
    /// Class Average for average information
    /// </summary>
    public class Average
    {
        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        public ItemType ItemType { get; set; }
        /// <summary>
        /// Gets or sets the average.
        /// </summary>
        /// <value>The average.</value>
        public double Avg { get; set; }
    }
}