using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Iot.Common;
using Iot.Data.EF;
using Iot.Models;
using IoT.Web.Base;

namespace IoT.Web.Controllers
{
    /// <summary>
    /// Class ItemApiController for getting data to the desktop via json
    /// </summary>
    [RoutePrefix("items")]
    public class ItemApiController : BaseApiController
    {
        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataController" /> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public ItemApiController(IotUow uow) : base(uow)
        {
        }

        #endregion

        /// <summary>
        /// Gets the item types.
        /// </summary>
        /// <returns>Dictionary&lt;System.Int32, System.String&gt;.</returns>
        [Route("types")]
        [HttpGet]
        public Dictionary<string, int> GetItemTypes()
        {
            var itemTypes = new Dictionary<string, int>();

            foreach (var currentEnum in Enum.GetValues(typeof(ItemType)))
            {
                itemTypes.Add(Enum.GetName(typeof(ItemType), currentEnum), (int)currentEnum);
            }

            return itemTypes;
        }

        /// <summary>
        /// get all items as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;List&lt;Item&gt;&gt;.</returns>
        [Route("all")]
        [HttpGet]
        public async Task<List<Item>> GetAllItemsAsync()
        {
            var items = await Database.ItemRepository.GetAllAsnyc();
            return items;
        }

        /// <summary>
        /// gettems by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        [Route("item/{itemId}/byid")]
        [HttpGet]
        public async Task<HttpResponseMessage> GettemsByIdAsync(int itemId)
        {
            var item = await Database.ItemRepository.FindSingleAsync(d => d.ItemId == itemId);

            if (item == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                                                   $"Item with item id {itemId} is not present in database");

            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        /// <summary>
        /// Searches the items by item types.
        /// </summary>
        /// <param name="itemTypeValue">The item type value.</param>
        /// <returns>List&lt;Item&gt;.</returns>
        [Route("search/{itemTypeValue}/byitemtype")]
        [HttpGet]
        public async Task<HttpResponseMessage> SearchItemsByItemTypes(string itemTypeValue)
        {
            List<Item> list;
            try
            {
                var itemType = itemTypeValue.ParseAsEnum<ItemType>();
                list =await Database.ItemRepository.FindAsync(d => d.Type == itemType);
            }
            catch (Exception err)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                                   $"An error has occurred {err.Message}");
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        /// <summary>
        /// Searches the items by date.
        /// </summary>
        /// <param name="from">From date.</param>
        /// <param name="to">To date.</param>
        /// <returns>HttpResponseMessage.</returns>
        /// <remarks>if to is empty or null, then only from is applied</remarks>
        [Route("search/{from}/date/{to?}")]
        [HttpGet]
        public async Task<HttpResponseMessage> SearchItemsByDate(DateTime from, DateTime? to)
        {
            List<Item> list;
            try
            {
                list =await Database.ItemRepository.FindAsync(d => d.TimeAdded > from);

                if (to.HasValue)
                    list = list.Where(d => d.TimeAdded <= to.Value).ToList();
            }
            catch (Exception err)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                                   $"An error has occurred {err.Message}");
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
    }
}