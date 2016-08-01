namespace Iot.Models
{
    /// <summary>
    /// Class DeviceDetails for getting device details with quick stats
    /// </summary>
    public class DeviceDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public DeviceDetails()
        {
            QuickStats = new QuickStat();
        }

        /// <summary>
        /// Gets or sets the device.
        /// </summary>
        /// <value>The device.</value>
        public Device Device { get; set; }
        /// <summary>
        /// Gets or sets the quick stats.
        /// </summary>
        /// <value>The quick stats.</value>
        public QuickStat QuickStats { get; set; } 
    }
}