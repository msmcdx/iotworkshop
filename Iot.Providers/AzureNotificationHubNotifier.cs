using System.Threading.Tasks;
using Iot.Interfaces;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Azure.NotificationHubs.Messaging;

namespace Iot.Providers
{

    /// <summary>
    /// Class PushNotification for working with push notifications
    /// </summary>
    public class AzureNotificationHubNotifier : IPushNotifier
    {
        /// <summary>
        /// The client
        /// </summary>
        private NotificationHubClient client;

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public NotificationHubClient Instance => client ??
                                                         (client =
                                                             NotificationHubClient.CreateClientFromConnectionString(
                                                                 FullAccessNamespace,
                                                                 HubName));

        /// <summary>
        /// Gets or sets the full access namespace.
        /// </summary>
        /// <value>The full access namespace.</value>
        public string FullAccessNamespace { get; set; }

        /// <summary>
        /// Gets or sets the name of the hub.
        /// </summary>
        /// <value>The name of the hub.</value>
        public string HubName { get; set; }

        /// <summary>
        /// Registers the device for push asynchronous.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="registrationUrl">The registration URL.</param>
        /// <returns>System.Threading.Tasks.Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> RegisterDeviceForPushAsync(string deviceName, string registrationUrl)
        {
            var registration = new WindowsRegistrationDescription(registrationUrl);
            registration.Tags.Add("device:" + deviceName);
            try
            {
                await Instance.CreateOrUpdateRegistrationAsync(registration);
            }
            catch (MessagingException e)
            {
                //TODO: log exception
                return false;
            }
            return true;
        }

        /// <summary>
        /// Uns the register device for push asynchronous.
        /// </summary>
        /// <param name="registrationUrl">Name of the device.</param>
        /// <returns>System.Threading.Tasks.Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> UnRegisterDeviceForPushAsync(string registrationUrl)
        {
            //get data about the device name
            await Instance.DeleteRegistrationAsync(registrationUrl);

            return true;
        }

        /// <summary>
        /// send push notification as an asynchronous operation.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="toastTemplate">The toast template.</param>
        /// <returns>
        ///   <c>true</c>, if completed or <c>false</c> otherwise</returns>
        public async Task<bool> SendPushNotificationAsync(string deviceName, string toastTemplate)
        {
            deviceName = "device:" + deviceName;
            
            var notificationOutcome =
                string.IsNullOrEmpty(deviceName) ? 
                await Instance.SendWindowsNativeNotificationAsync(toastTemplate) :
                await Instance.SendWindowsNativeNotificationAsync(toastTemplate, deviceName);

            if (notificationOutcome == null) return false;
            
            if (!((notificationOutcome.State == NotificationOutcomeState.Abandoned) ||
                    (notificationOutcome.State == NotificationOutcomeState.Unknown)))
            {
                return true;
            }

            return false; //TODO: log - there was internal server error
        }
    }
}