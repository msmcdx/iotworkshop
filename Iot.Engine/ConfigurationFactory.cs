using System;
using System.Configuration;
using Iot.Interfaces;

namespace Iot.Engine
{
    /// <summary>
    /// Class ConfigurationFactory, which is the implementation of the <code>IConfigurationFactory</code>
    /// </summary>
    public class ConfigurationFactory : IConfigurationFactory
    {
        /// <summary>
        /// Gets the mailer, which enables us to send emails.
        /// </summary>
        /// <returns>IMailer instance or null otherwise.</returns>
        /// <exception cref="System.ApplicationException">There is no iot section defined!</exception>
        public IMailer GetMailer()
        {
            //get the mailer from configuration
            var section = GetConfigurationSection();

            var mailerType = Activator.CreateInstance(Type.GetType(section.Mailer.Type)) as IMailer;

            //set the additional data from
            mailerType.Server = section.Mailer.Server;
            mailerType.Username = section.Mailer.Username;
            mailerType.Password = section.Mailer.Password;
            mailerType.DefaultMailTo = section.Mailer.DefaultMailTo;

            return mailerType;
        }

        /// <summary>
        /// Gets the file worker.
        /// </summary>
        /// <returns>IFileWorker.</returns>
        public IFileWorker GetFileWorker()
        {
            var section = GetConfigurationSection();

            var fileWorker = Activator.CreateInstance(Type.GetType(section.FileWorker.Type)) as IFileWorker;

            fileWorker.ContainerName = section.FileWorker.RootPath;

            if (!string.IsNullOrEmpty(section.FileWorker.AccountName))
                fileWorker.AccountName = section.FileWorker.AccountName;

            if (!string.IsNullOrEmpty(section.FileWorker.AccountKey))
                fileWorker.AccountKey = section.FileWorker.AccountKey;

            return fileWorker;
        }

        /// <summary>
        /// Gets the push notification.
        /// </summary>
        /// <returns>IPushNotification or null otherwise.</returns>
        public IPushNotifier GetPushNotification()
        {
            var section = GetConfigurationSection();

            var pushNotificationType = Activator.CreateInstance(Type.GetType(section.PushNotification.Type)) as IPushNotifier;

            //set the additional data from configuration
            if (!string.IsNullOrEmpty(section.PushNotification.FullAccessNamespace))
                pushNotificationType.FullAccessNamespace = pushNotificationType.FullAccessNamespace;

            if (!string.IsNullOrEmpty(section.PushNotification.HubName))
                pushNotificationType.HubName = pushNotificationType.HubName;

            return pushNotificationType;
        }

        /// <summary>
        /// Gets the IOT configuration section.
        /// </summary>
        /// <returns>IotConfigurationSection.</returns>
        /// <exception cref="System.ApplicationException">There is no IOT section defined!</exception>
        /// <value>The IOT configuration section.</value>
        private IotConfigurationSection GetConfigurationSection()
        {
            var section =
                    ConfigurationManager.GetSection(StringConstants.IotConfigurationSectionName) as
                            IotConfigurationSection;

            if (section == null) throw new ApplicationException("There is no IOT section defined!");
            return section;
        }
    }
}