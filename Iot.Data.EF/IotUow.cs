using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;
using Iot.Interfaces;

namespace Iot.Data.EF
{
    /// <summary>
    /// implementation of Unit of work pattern.
    /// </summary>
    public class IotUow : IIotUOW
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IotUow" /> class.
        /// </summary>
        public IotUow()
        {
            ItemRepository = new ItemRepository(DbContext);
            DeviceRepository = new DeviceRepository(DbContext);
            PushNotificationRepository = new PushNotificationRepository(DbContext);
            CategoryRepository = new CategoryRepository(DbContext);
            DownloadRepository = new DownloadRepository(DbContext);
            PushNotificationTemplateRepository = new PushNotificationTemplateRepository(DbContext);
            PushNotificationTemplateTypeRepository = new PushNotificationTemplateTypeRepository(DbContext);
        }

        /// <summary>
        /// commit as an asynchronous operation.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if data is commited to database, <c>false</c> otherwise.</returns>
        public async Task<bool> CommitAsync()
        {
            DbContextTransaction transaction = null;
            try
            {
                var dbConnection = DbContext.Database.Connection;

                if (dbConnection == null)
                    throw new Exception("Database connection is not present!");

                //open connection
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();

                using (transaction = DbContext.Database.BeginTransaction())
                {
                    var changes = await DbContext.SaveChangesAsync();
                    transaction.Commit();
                    return changes > 0; //if there is any data} catch (Exception EX_NAME)
                }
            }
            catch (Exception err)
            {
                transaction?.Rollback();

                //TODO: add logging framework
                Debug.WriteLine(err);
                return false;
            }
        }

        /// <summary>
        /// Gets the device repository.
        /// </summary>
        /// <value>The device repository.</value>
        public IDeviceRepository DeviceRepository { get; }
        /// <summary>
        /// Gets the item repository.
        /// </summary>
        /// <value>The item repository.</value>
        public IItemRepository ItemRepository { get; }
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

        /// <summary>
        /// Gets or sets the database context.
        /// </summary>
        /// <value>The database context.</value>
        public DbContext DbContext { get; set; } = new IotContext();

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
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
                DbContext?.Dispose();
        }

        #endregion
    }
}