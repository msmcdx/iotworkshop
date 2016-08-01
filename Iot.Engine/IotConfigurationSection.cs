using System.Configuration;

namespace Iot.Engine
{
    /// <summary>
    /// Class IotConfigurationSection, which represents settings for mailer config.
    /// </summary>
    public class IotConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets the mailer.
        /// </summary>
        /// <value>The mailer.</value>
        [ConfigurationProperty("mailer", IsRequired = true)]
        public MailerElement Mailer
        {
            get { return (MailerElement) base["mailer"]; }
            set { base["mailer"] = value; }
        }

        /// <summary>
        /// Gets or sets the mailer.
        /// </summary>
        /// <value>The mailer.</value>
        [ConfigurationProperty("fileworker", IsRequired = true)]
        public FileWorkerElement FileWorker
        {
            get { return (FileWorkerElement) base["fileworker"]; }
            set { base["fileworker"] = value; }
        }

        /// <summary>
        /// Gets or sets the push notification.
        /// </summary>
        /// <value>The push notification.</value>
        [ConfigurationProperty("pushnotification", IsRequired = true)]
        public PushNotificationElement PushNotification
        {
            get { return (PushNotificationElement) base["pushnotification"]; }
            set { base["pushnotification"] = value; }
        }
    }
}