using System.Data.Entity;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class DownloadRepository.
    /// </summary>
    public class DownloadRepository : DataRepository<Download>,IDownloadRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DownloadRepository(DbContext context) : base(context)
        {
        }
    }
}