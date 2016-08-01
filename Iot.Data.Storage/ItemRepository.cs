using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.Storage
{
    /// <summary>
    /// Class ItemRepository.
    /// </summary>
    public class ItemRepository : DataStorageRepository<Item>,IItemRepository
    {
         
    }
}