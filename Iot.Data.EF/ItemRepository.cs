using System.Data.Entity;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class ItemRepository.
    /// </summary>
    public class ItemRepository : DataRepository<Item>,IItemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ItemRepository(DbContext context) : base(context)
        {
        }
    }
}