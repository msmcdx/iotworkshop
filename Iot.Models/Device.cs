using System.Collections.Generic;

namespace Iot.Models
{
    /// <summary>
    /// Class Device.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        public int DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        public string SerialNumber{ get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is offline.
        /// </summary>
        /// <value><c>true</c> if this instance is offline; otherwise, <c>false</c>.</value>
        public bool IsOffline { get; set; }
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public List<Item> Items { get; set; } = new List<Item>();
    }
}