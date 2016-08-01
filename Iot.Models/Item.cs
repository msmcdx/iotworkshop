using System;

namespace Iot.Models
{
    /// <summary>
    /// Class Item, which represent an item, which device
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>The item identifier.</value>
        public int ItemId { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public ItemType Type { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the time added.
        /// </summary>
        /// <value>The time added.</value>
        public DateTime TimeAdded { get; set; }
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        public virtual int DeviceId { get; set; }
        /// <summary>
        /// Gets or sets the device.
        /// </summary>
        /// <value>The device.</value>
        public virtual Device Device { get; set; }
    }

    /// <summary>
    /// Enum ItemType
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// The temperature
        /// </summary>
        TEMPERATURE = 0,
        /// <summary>
        /// The humidity
        /// </summary>
        HUMIDITY
    }
}