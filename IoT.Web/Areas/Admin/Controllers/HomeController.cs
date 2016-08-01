using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Iot.Data.EF;
using Iot.Models;
using IoT.Web.Base;
using IoT.Web.ViewModels;
using PagedList;

namespace IoT.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// </summary>
    [Authorize]
    public class HomeController : BaseDataController
    {
        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataController" /> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public HomeController(IotUow uow) : base(uow)
        {
        }

        #endregion

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Deviceses this instance.
        /// </summary>
        /// <param name="page">current page</param>
        /// <param name="Query">The query.</param>
        /// <returns>ActionResult.</returns>
        public async Task<ViewResult> Devices(int? page, string Query = "")
        {
            var pageNumber = page ?? 1;
            //if there is an empty query, show all, otherwise search for it
            var listOfDevices = string.IsNullOrEmpty(Query)
                ? Database.DeviceRepository.GetAll().ToList()
                : await Database.DeviceRepository.FindAsync(d => d.Name.Contains(Query));

            var list = listOfDevices.ToPagedList(pageNumber, Helpers.SettingsHelper.DefaultPageSize);

            var devices = new AdminDevicesViewModel
            {
                Query = Query,
                Devices = list
            };

            return View(devices);
        }

        /// <summary>
        /// Reports the specified device identifier.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        public async Task<ActionResult> Report(int deviceId)
        {
            var device = await Database.DeviceRepository.FindSingleAsync(d => d.DeviceId == deviceId);

            if (device == null)
            {
                SetMessage($"Device with {deviceId} is not present in database!");
                return RedirectToAction("Devices");
            }

            var reportModel = new ReportDeviceViewModel
            {
                Device = device
            };

            return View(reportModel);
        }

        #region Admin part for devices

        /// <summary>
        /// Devices the add.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>ActionResult.</returns>
        public async Task<ActionResult> DeviceEdit(int deviceId)
        {
            var device = await Database.DeviceRepository.FindSingleAsync(d => d.DeviceId == deviceId);

            if (device == null)
            {
                SetMessage($"Device with {deviceId} is not present in database");
                return RedirectToAction("Devices");
            }

            return View(device);
        }

        /// <summary>
        /// Devices the edit.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [HttpPost]
        public async Task<ActionResult> DeviceEdit(Device device)
        {
            Database.DeviceRepository.Update(device);

            try
            {
                await Database.CommitAsync();
            }
            catch (Exception err)
            {
                SetMessage($"An error has occurred: {err.Message}");
                return RedirectToAction("Devices");
            }

            return RedirectToAction("Devices");
        }

        /// <summary>
        /// Devices the add.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns>ActionResult.</returns>
        public async Task<ActionResult> DeviceDelete(int deviceId)
        {
            var device = await Database.DeviceRepository.FindSingleAsync(d => d.DeviceId == deviceId);

            if (device == null)
            {
                SetMessage($"Device with {deviceId} is not present in database!");
                return RedirectToAction("Devices");
            }

            return View(device);
        }

        /// <summary>
        /// Devices the delete.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>Task&lt;RedirectToRouteResult&gt;.</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> DeviceDelete(Device device)
        {
            Database.DeviceRepository.Delete(device);

            try
            {
                await Database.CommitAsync();
            }
            catch (Exception err)
            {
                SetMessage($"An error has occured {err.Message}");
            }

            SetMessage($"Device {device.Name} has been deleted from database!");

            return RedirectToAction("Devices");
        }

        /// <summary>
        /// Devices the add.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult DeviceAdd()
        {
            return View(new Device());
        }

        /// <summary>
        /// Devices the add.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>Task&lt;RedirectToRouteResult&gt;.</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> DeviceAdd(Device device)
        {
            Database.DeviceRepository.Add(device);

            try
            {
                await Database.CommitAsync();
            }
            catch (Exception err)
            {
                //TODO: log it
                SetMessage($"An error occured {err.Message}");
            }

            SetMessage($"Device {device.Name} has been successfully added to the database!");

            return RedirectToAction("Devices");
        }

        #endregion 
    }
}