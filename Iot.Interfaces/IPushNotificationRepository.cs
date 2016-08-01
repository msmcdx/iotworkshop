using System.Threading.Tasks;
using Iot.Models;

namespace Iot.Interfaces
{
    /// <summary>
    /// Interface IPushNotificationRepository
    /// </summary>
    public interface IPushNotificationRepository : IRepository<PushNotificationInfo>
    {
        /// <summary>
        /// Gets the push notification information by device name asynchronous.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <returns><c>PushNotificationInfo</c> or <c>null</c> otherwise</returns>
        Task<PushNotificationInfo> GetByDeviceNameAsync(string deviceName);
    }
}