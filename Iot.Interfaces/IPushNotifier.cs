using System.Threading.Tasks;

namespace Iot.Interfaces
{
    /// <summary>
    /// Interface IPushNotifier
    /// </summary>
    public interface IPushNotifier
    {
        /// <summary>
        /// Gets or sets the full access namespace.
        /// </summary>
        /// <value>The full access namespace.</value>
        string FullAccessNamespace { get; set; }
        /// <summary>
        /// Gets or sets the name of the hub.
        /// </summary>
        /// <value>The name of the hub.</value>
        string HubName { get; set; }
        /// <summary>
        /// Registers the device for push asynchronous.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="registrationUrl">The registration URL.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> RegisterDeviceForPushAsync(string deviceName, string registrationUrl);
        /// <summary>
        /// Sends the push notification asynchronous.
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        /// <param name="toastTemplate">The toast template.</param>
        /// <returns><c>true</c> if sending was a success or <c>false</c> otherwise</returns>
        /// <remarks>if <c>deviceName</c> is empty, then message is sent to all of the registered devices</remarks>
        Task<bool> SendPushNotificationAsync(string deviceName, string toastTemplate);
        /// <summary>
        /// Uns the register device for push asynchronous.
        /// </summary>
        /// <param name="registrationUrl">registration url of the device.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> UnRegisterDeviceForPushAsync(string registrationUrl);
    }
}