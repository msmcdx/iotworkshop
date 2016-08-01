using Iot.Models;
using PagedList;

namespace IoT.Web.ViewModels
{
    /// <summary>
    /// Class SearchViewModel for providing search results
    /// </summary>
    public class SearchViewModel
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>The query.</value>
        public string Query { get; set; }
        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>The devices.</value>
        public IPagedList<Device> Devices { get; set; }
    }
}