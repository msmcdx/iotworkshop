using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using Iot.Data.EF;
using Iot.Engine;
using Iot.Interfaces;
using Iot.Models;
using IoT.Web.Base;
using IoT.Web.ViewModels;
using PagedList;

namespace IoT.Web.Controllers
{
    /// <summary>
    /// Class WebPartController for working with web part of the workshop
    /// </summary>
    public class WebPartController : BaseDataController
    {
        /// <summary>
        /// The configuration factory
        /// </summary>
        private readonly IConfigurationFactory configurationFactory;

        /// <summary>
        /// The cache service
        /// </summary>
        private readonly ICacheService cacheService;

        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataController" /> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        /// <param name="configurationFactory">configuration factory</param>
        /// <param name="cacheService">cache service</param>
        public WebPartController(IotUow uow,
            IConfigurationFactory configurationFactory,
            ICacheService cacheService) : base(uow)
        {
            this.configurationFactory = configurationFactory;
            this.cacheService = cacheService;
        }

        #endregion

        /// <summary>
        /// Downloads the information.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult DownloadInfo()
        {
            return View();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public async Task<ViewResult> Chart()
        {
            var list = await Database.DeviceRepository.GetAllAsnyc();
            ViewBag.Devices = list.Select(d => new SelectListItem { Text = d.Name, Value = d.DeviceId.ToString() });
            return View();
        }

        /// <summary>
        /// Filter items
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [Route("filter/{Query?}/{PageNumber?}")]
        //[OutputCache(VaryByParam = "Query,PageNumber", Duration = 10)]
        public async Task<ViewResult> Filtering(SearchViewModel model)
        {
            //filter devices based on search query
            var devices = await GetDevicesBasedOnQuery(model.Query);

            var list = devices.ToPagedList(model.PageNumber, Helpers.SettingsHelper.DefaultPageSize);

            model.Devices = list;

            return View(model);
        }

        /// <summary>
        /// Gets the devices based on query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Task&lt;List&lt;Device&gt;&gt; or all devices instead</returns>
        private async Task<List<Device>> GetDevicesBasedOnQuery(string query)
        {
            List<Device> listOfDevices;
            if (string.IsNullOrEmpty(query))
                listOfDevices = cacheService.GetOrSet("DeviceByQuery",
                    () => Database.DeviceRepository.GetAll(d => d.Items).ToList());
            else
                listOfDevices = await Database.DeviceRepository.FindAsync(d => d.Name.Contains(query), d => d.Items);
            return listOfDevices;
        }

        /// <summary>
        /// Exports to excell.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public async Task<FileContentResult> ExportToExcell()
        {
            SetMessage("Data has been proccessed!");

            string query = string.Empty;
            if (Request.QueryString.AllKeys.Contains("Query"))
                query = Request.QueryString["Query"];

            var devices = await GetDevicesBasedOnQuery(query);

            var listToExport = new List<ExportData>();

            devices.ForEach(d => listToExport.Add(new ExportData
            {
                Name = d.Name,
                Description = d.Description,
                ItemCount = d.Items.Count,
                SerialNumber = d.SerialNumber
            }));

            var xmlSerializer = new XmlSerializer(listToExport.GetType());

            var xmlDoc = new XmlDocument();

            string xml;

            using (var xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, listToExport);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                xml = xmlDoc.InnerXml;
            }

            byte[] fileContents = Encoding.UTF8.GetBytes(xml);
            return File(fileContents, "application/vnd.ms-excel", "DeviceExport.xls");
        }

        /// <summary>
        /// Pushes the notification.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult PushNotification()
        {
            return View();
        }

        /// <summary>
        /// Does the push notification.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        public async Task<ActionResult> DoPushNotification(int deviceId)
        {
            var device = await Database.DeviceRepository.FindSingleAsync(d => d.DeviceId == deviceId);

            if (device == null)
                return RedirectToAction("Filtering");

            //get pushnotification types
            var pushTypes = await Database.PushNotificationTemplateTypeRepository.GetAllAsnyc();
            ViewBag.PushTypes = pushTypes;

            //show the form
            return View(device);
        }

        /// <summary>
        /// Does the push notification.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public async Task<ActionResult> DoPushNotification(Device device)
        {
            var pushNotifier = configurationFactory.GetPushNotification();

            //get from database
            var deviceName = device.Name;
            try
            {
                var pushNotificationInfo = await Database.PushNotificationRepository
                    .GetByDeviceNameAsync(deviceName);

                //check or register the device to send it
                await pushNotifier.RegisterDeviceForPushAsync(deviceName,
                    pushNotificationInfo.RegistrationChannel);

                //send based on selected template
                await pushNotifier.SendPushNotificationAsync(deviceName, "");
            }
            catch (Exception e)
            {
                //TODO: log exception
                SetMessage($"There was an exception with sending Push Notification {e.Message}");
                return RedirectToAction("DoPushNotification", new { deviceId = device.DeviceId });
            }

            SetMessage($"Push Notification to the {deviceName} was sent at {DateTime.Now}.");

            return RedirectToAction("DoPushNotification", new {deviceId = device.DeviceId});
        }
    }
}