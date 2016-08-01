using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class DeviceRepository - a implementation of <c>IDeviceRepository</c>
    /// </summary>
    public class DeviceRepository : DataRepository<Device>, IDeviceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DeviceRepository(DbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the online devices asynchronous.
        /// </summary>
        /// <returns>Task&lt;List&lt;Device&gt;&gt;.</returns>
        public Task<List<Device>> GetOnlineDevicesAsync()
        {
            return FindAsync(d => d.IsOffline);
        }
    }
}