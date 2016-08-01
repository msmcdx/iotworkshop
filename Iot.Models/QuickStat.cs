using System.Collections.Generic;

namespace Iot.Models
{
    /// <summary>
    /// Class QuickStat for getting quick stats
    /// </summary>
    public class QuickStat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public QuickStat()
        {
            Averages = new List<Average>();
        }

        /// <summary>
        /// Gets or sets the item count.
        /// </summary>
        /// <value>The item count.</value>
        public int ItemCount { get; set; }
        /// <summary>
        /// Gets or sets the averages.
        /// </summary>
        /// <value>The averages.</value>
        public List<Average> Averages { get; set; }

        /// <summary>
        /// Gets or sets the highest value.
        /// </summary>
        /// <value>The highest value.</value>
        public double HighestValue { get; set; }
    }
}