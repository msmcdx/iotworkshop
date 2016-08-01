using System;
using System.Threading.Tasks;

namespace Iot.Interfaces
{
    /// <summary>
    /// Interface IIotUOW, which handles the save
    /// </summary>
    public interface IIotUOW : IDisposable
    {
        /// <summary>
        /// Commits all the changes to data storage.
        /// </summary>
        /// <returns><c>true</c> if data is commited to database, <c>false</c> otherwise.</returns>
        Task<bool> CommitAsync();
        /// <summary>
        /// Gets the device repository.
        /// </summary>
        /// <value>The device repository.</value>
        IDeviceRepository DeviceRepository { get; }
        /// <summary>
        /// Gets the item repository.
        /// </summary>
        /// <value>The item repository.</value>
        IItemRepository ItemRepository { get; }
        /// <summary>
        /// Gets the push notification repository.
        /// </summary>
        /// <value>The push notification repository.</value>
        IPushNotificationRepository PushNotificationRepository { get; }
        /// <summary>
        /// Gets the download repository.
        /// </summary>
        /// <value>The download repository.</value>
        IDownloadRepository DownloadRepository { get; }
        /// <summary>
        /// Gets the category repository.
        /// </summary>
        /// <value>The category repository.</value>
        ICategoryRepository CategoryRepository { get; }
        /// <summary>
        /// Gets the push notification template repository.
        /// </summary>
        /// <value>The push notification template repository.</value>
        IPushNotificationTemplateRepository PushNotificationTemplateRepository { get; }
        /// <summary>
        /// Gets the push notification template type repository.
        /// </summary>
        /// <value>The push notification template type repository.</value>
        IPushNotificationTemplateTypeRepository PushNotificationTemplateTypeRepository { get; }
    }
}