using System.Collections.Generic;
using System.Threading.Tasks;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.Storage
{
    /// <summary>
    /// Class DeviceRepository.
    /// </summary>
    public class DeviceRepository : DataStorageRepository<Device>, IDeviceRepository
    {
        /// <summary>
        /// Gets the online devices asynchronous.
        /// </summary>
        /// <returns>Task&lt;List&lt;Device&gt;&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<List<Device>> GetOnlineDevicesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}