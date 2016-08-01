using System.Threading.Tasks;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.Storage
{
    /// <summary>
    /// Class PushNotificationRepository.
    /// </summary>
    public class PushNotificationRepository : DataStorageRepository<PushNotificationInfo>,IPushNotificationRepository
    {
        /// <summary>
        /// Gets the push notification information by device name asynchronous.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <returns><c>PushNotificationInfo</c> or <c>null</c> otherwise</returns>
        public Task<PushNotificationInfo> GetByDeviceNameAsync(string deviceName)
        {
            throw new System.NotImplementedException();
        }
    }
}