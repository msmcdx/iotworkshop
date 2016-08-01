using Iot.Interfaces;

namespace Iot.Engine
{
    /// <summary>
    /// Interface IConfigurationFactory, which represents bridge between configuration in a config file and the component
    /// </summary>
    /// <remarks>
    ///     based on Miguel Castro's pipeline framework - https://github.com/miguelcastro67/pipeline-framework
    /// </remarks>
    public interface IConfigurationFactory
    {
        /// <summary>
        /// Gets the mailer, which enables us to send emails.
        /// </summary>
        /// <returns>IMailer instance or null otherwise.</returns>
        IMailer GetMailer();

        /// <summary>
        /// Gets the file worker.
        /// </summary>
        /// <returns>IFileWorker.</returns>
        IFileWorker GetFileWorker();

        /// <summary>
        /// Gets the push notification.
        /// </summary>
        /// <returns>IPushNotification or null otherwise.</returns>
        IPushNotifier GetPushNotification();
    }
}