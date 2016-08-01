using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.WebPages;
using Iot.Data.EF;
using Iot.Models;
using IoT.Web.Base;

namespace IoT.Web.Controllers
{
    /// <summary>
    /// Class DeviceApiController, where you can get data about devices
    /// </summary>
    [RoutePrefix("devices")]
    public class DeviceApiController : BaseApiController
    {
        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataController" /> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public DeviceApiController(IotUow uow) : base(uow)
        {
        }

        #endregion

        /// <summary>
        /// Adds the device.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        [HttpPost]
        [Route("add")]
        public async Task<HttpResponseMessage> AddDevice(Device device)
        {
            if (device == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                    "Device not recognized!");

            var deviceInDatabase = await Database.DeviceRepository.FindSingleAsync(d => d.SerialNumber == device.SerialNumber);

            if (deviceInDatabase == null)
            {
                //add the device
                Database.DeviceRepository.Add(device);

                try
                {
                    await Database.CommitAsync();
                }
                catch (Exception err)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    err.Message);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, device.DeviceId);
        }

        /// <summary>
        /// Adds the item to device.
        /// </summary>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="item">The item.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        [HttpPost]
        [Route("items/add")]
        public async Task<HttpResponseMessage> AddItemToDevice([FromBody]string serialNumber,
           Item item)
        {
            if (string.IsNullOrEmpty(serialNumber))
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                    "Serial number not recognized!");

            var deviceInDatabase = await Database.DeviceRepository
                .FindSingleAsync(d => d.SerialNumber == serialNumber,
                d => d.Items);

            //if (deviceInDatabase == null)
            //    return Request.CreateErrorResponse(HttpStatusCode.NoContent,
            //        $"Device with serial number {serialNumber} not recognized!");

            if (deviceInDatabase == null)
            {
                var device = new Device
                {
                    SerialNumber = serialNumber,
                    Description = "Device with serial number " + serialNumber,
                    IsOffline = false,
                    Name = serialNumber
                };

                //add the device
                Database.DeviceRepository.Add(device);

                try
                {
                    await Database.CommitAsync();
                }
                catch (Exception err)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    err.Message);
                }

                //set data from the newly created device
                deviceInDatabase = await Database.DeviceRepository
                .FindSingleAsync(d => d.DeviceId == device.DeviceId,
                d => d.Items); //we need items to add the data from item to
            }

            if (item == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                    $"Device with SN {serialNumber} recognized, item value empty!");

            //add item to the database
            item.TimeAdded = DateTime.Now;
            item.DeviceId = deviceInDatabase.DeviceId;

            deviceInDatabase.Items.Add(item);

            try
            {
                await Database.CommitAsync();
            }
            catch (Exception err)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    err.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, deviceInDatabase.Items.Count);
        }

        /// <summary>
        /// Gets all devices.
        /// </summary>
        /// <returns>Task&lt;List&lt;Device&gt;&gt;.</returns>
        [Route("all")]
        [HttpGet]
        public async Task<List<Device>> GetAllDevicesAsnyc()
        {
            var devices = await Database.DeviceRepository.GetAllAsnyc(d => d.Items);
            return devices;
        }

        /// <summary>
        /// get all devices without items as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;List&lt;Device&gt;&gt;.</returns>
        [Route("allwithoutitems")]
        [HttpGet]
        public async Task<List<Device>> GetAllDevicesWithoutItemsAsync()
        {
            var devices = await Database.DeviceRepository.GetAllAsnyc();
            return devices;
        }

        /// <summary>
        /// Gets the device asnyc.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        [Route("{deviceId}/byid")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetDevicebyIdAsnyc(int deviceId)
        {
            var device = await Database.DeviceRepository.FindSingleAsync(d => d.DeviceId == deviceId,
                d => d.Items);

            if (device == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                                                   $"Device with device id {deviceId} is not present in database");

            var stats = new DeviceDetails { Device = device };

            //get quickstats
            var quickStats = new QuickStat
            {
                ItemCount = device.Items?.Count ?? 0
            };

            var highestValue = device.Items?.Max(d => d.Value) ?? "0";
            quickStats.HighestValue = Convert.ToDouble(highestValue);

            //get additional stats - average based on item type
            var currentStats = from d in device.Items
                               group d by d.Type
                into itemType
                               select new
                               {
                                   ItemType = itemType,
                                   Avg = itemType.Select(g => Convert.ToDouble(g.Value)).Average()
                               };

            //set the average details for us to be able to get more info
            var list = new List<Average>();
            foreach (var currentStat in currentStats)
            {
                list.Add(new Average
                {
                    ItemType = currentStat.ItemType.Key,
                    Avg = currentStat.Avg
                });
            }

            quickStats.Averages = list;

            stats.QuickStats = quickStats;

            return Request.CreateResponse(HttpStatusCode.OK, stats);
        }

        /// <summary>
        /// Gets the items for device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>System.Threading.Tasks.Task&lt;System.Net.Http.HttpResponseMessage&gt;.</returns>
        [Route("{deviceId}/items/temp")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetItemsWithTempForDeviceId(int deviceId)
        {
            var device = await Database.DeviceRepository.FindSingleAsync(d => d.DeviceId == deviceId,
                d => d.Items);

            if (device == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                                                   $"Device with device id {deviceId} is not present in database");

            var items = device.Items.Where(d => d.Type == ItemType.TEMPERATURE).ToList();

            //items.ForEach(d=>d.TimeAdded = Convert.ToDateTime(d.TimeAdded.ToShortDateString()));
            var list = from c in items
                       select new { c.Value, TimeAdded = c.TimeAdded.ToString("d") };
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        /// <summary>
        /// Gets the items with humidity for device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>System.Threading.Tasks.Task&lt;System.Net.Http.HttpResponseMessage&gt;.</returns>
        [Route("{deviceId}/items/hum")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetItemsWithHumidityForDeviceId(int deviceId)
        {
            var device = await Database.DeviceRepository.FindSingleAsync(d => d.DeviceId == deviceId,
                d => d.Items);

            if (device == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                                                   $"Device with device id {deviceId} is not present in database");

            var items = device.Items.Where(d => d.Type == ItemType.HUMIDITY);
            return Request.CreateResponse(HttpStatusCode.OK, items.ToList());
        }

        /// <summary>
        /// Gets the device asnyc.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        [Route("search/{searchTerm}")]
        [HttpGet]
        public async Task<HttpResponseMessage> SearchDevices(string searchTerm = "")
        {
            var devices = string.IsNullOrEmpty(searchTerm) ?
                Database.DeviceRepository.GetAll().ToList() :
                await Database.DeviceRepository.FindAsync(d => d.Name.Contains(searchTerm));

            if (!devices.Any())
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                                                   $"Devices based on {searchTerm} are not present in database");

            return Request.CreateResponse(HttpStatusCode.OK, devices);
        }

        /// <summary>
        /// Gets the device asnyc.
        /// </summary>
        /// <param name="sn">The sn.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        [Route("{sn}/bysn")]
        public async Task<HttpResponseMessage> GetDeviceBySNAsnyc(string sn)
        {
            var device = await Database.DeviceRepository.FindSingleAsync(d => d.SerialNumber == sn);

            if (device == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent,
                                                   $"Device with serial number {sn} is not present in database");

            return Request.CreateResponse(HttpStatusCode.OK, device);
        }
    }
}