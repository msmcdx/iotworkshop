using System;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class PushNotificationRepository.
    /// </summary>
    public class PushNotificationRepository : DataRepository<PushNotificationInfo>,IPushNotificationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public PushNotificationRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the push notification information by device name asynchronous.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <returns><c>PushNotificationInfo</c> or <c>null</c> otherwise</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<PushNotificationInfo> GetByDeviceNameAsync(string deviceName)
        {
            if (string.IsNullOrEmpty(deviceName)) 
                throw new Exception("Device name not specified!");

            return FindSingleAsync(d => d.Device.Name == deviceName);
        }
    }
}