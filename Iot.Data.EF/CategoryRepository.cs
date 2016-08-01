using System.Data.Entity;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class CategoryRepository.
    /// </summary>
    public class CategoryRepository : DataRepository<Category>,ICategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}