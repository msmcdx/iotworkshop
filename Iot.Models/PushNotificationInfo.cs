namespace Iot.Models
{
    /// <summary>
    /// Class PushNotificationInfo, which is required for pushing notification to specific devices.
    /// </summary>
    public class PushNotificationInfo
    {
        /// <summary>
        /// Gets or sets the push notification identifier.
        /// </summary>
        /// <value>The push notification identifier.</value>
        public int PushNotificationInfoId { get; set; }
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        public string DeviceId { get; set; }
        /// <summary>
        /// Gets or sets the device.
        /// </summary>
        /// <value>The device.</value>
        public Device Device { get; set; }
        /// <summary>
        /// Gets or sets the registration channel.
        /// </summary>
        /// <value>The registration channel.</value>
        public string RegistrationChannel { get; set; } 
    }
}