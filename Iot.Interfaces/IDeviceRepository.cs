using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Iot.Models;

namespace Iot.Interfaces
{
    /// <summary>
    /// Interface IDeviceRepository, which is resposible for working with
    /// </summary>
    public interface IDeviceRepository : IRepository<Device>
    {
        /// <summary>
        /// Gets the online devices asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Device&gt;&gt; or empty list.</returns>
        Task<List<Device>> GetOnlineDevicesAsync();
    }
}