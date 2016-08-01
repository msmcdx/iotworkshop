using System.Collections.Generic;
using Iot.Models;
using PagedList;

namespace IoT.Web.ViewModels
{
    /// <summary>
    /// Class AdminDevicesViewModel.
    /// </summary>
    public class AdminDevicesViewModel
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>The query.</value>
        public string Query { get; set; }
        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>The devices.</value>
        public IPagedList<Device> Devices { get; set; } = new StaticPagedList<Device>(new List<Device>(), 1, 1, 0);
    }
}