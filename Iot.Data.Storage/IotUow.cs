using System;
using System.Threading.Tasks;
using Iot.Interfaces;

namespace Iot.Data.Storage
{
    /// <summary>
    /// Class IotUow, which represents unit of work pattern, which works with Azure Table Storage
    /// </summary>
    public class IotUow : IIotUOW
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///   <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO: clean all the repositories and connection to table storage
            }
        }

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<bool> CommitAsync()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the device repository.
        /// </summary>
        /// <value>The device repository.</value>
        public IDeviceRepository DeviceRepository { get; } = new DeviceRepository();
        /// <summary>
        /// Gets the item repository.
        /// </summary>
        /// <value>The item repository.</value>
        public IItemRepository ItemRepository { get; } = new ItemRepository();

        /// <summary>
        /// Gets the push notification repository.
        /// </summary>
        /// <value>The push notification repository.</value>
        public IPushNotificationRepository PushNotificationRepository { get; }

        /// <summary>
        /// Gets the download repository.
        /// </summary>
        /// <value>The download repository.</value>
        public IDownloadRepository DownloadRepository { get; }
        /// <summary>
        /// Gets the category repository.
        /// </summary>
        /// <value>The category repository.</value>
        public ICategoryRepository CategoryRepository { get; }

        /// <summary>
        /// Gets the push notification template repository.
        /// </summary>
        /// <value>The push notification template repository.</value>
        public IPushNotificationTemplateRepository PushNotificationTemplateRepository { get; }

        /// <summary>
        /// Gets the push notification template type repository.
        /// </summary>
        /// <value>The push notification template type repository.</value>
        public IPushNotificationTemplateTypeRepository PushNotificationTemplateTypeRepository { get; }
    }
}