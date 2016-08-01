using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Iot.Data.EF;
using Iot.Engine;
using Iot.Interfaces;
using Iot.Models;
using IoT.Web.Base;
using IoT.Web.ViewModels;
using Microsoft.Practices.ObjectBuilder2;
using PagedList;

namespace IoT.Web.Controllers
{
    /// <summary>
    /// Class DownloadController for showing and working with download options
    /// </summary>
    [RoutePrefix("downloads")]
    public class DownloadController : BaseDataController
    {
        /// <summary>
        /// The factory
        /// </summary>
        private readonly IConfigurationFactory factory;

        /// <summary>
        /// The cache service
        /// </summary>
        private readonly ICacheService cacheService;

        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataController" /> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        /// <param name="factory">factory with all providers</param>
        /// <param name="cacheService">cache service</param>
        public DownloadController(IotUow uow, IConfigurationFactory factory, ICacheService cacheService) : base(uow)
        {
            this.factory = factory;
            this.cacheService = cacheService;
        }

        #endregion

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>ActionResult.</returns>
        public async Task<ActionResult> Index(int? page)
        {
            int pageNumer = page ?? 1;

            var list = await Database.DownloadRepository.GetAllAsnyc(d => d.Categories);

            list.ForEach(d => d.ImageUrl = Server.MapPath("~/Images/") + d.ImageUrl);

            if (Session["CategoryList"] == null)
            {
                var categories = await Database.CategoryRepository.GetAllAsnyc();
                var categoryList =
                    categories.Select(d => new CategoryViewModel { Category = d, Selected = false }).ToList();
                ViewBag.Categories = categoryList;
            }
            else
            {
                var selectedCategories = (List<CategoryViewModel>)Session["CategoryList"];
                ViewBag.Categories = selectedCategories;

                //filter data
                //TODO: change the implementation to beter, perfomance efficient option
                var tempList = new List<Download>();
                foreach (var currentData in selectedCategories.Where(d => d.Selected))
                {
                    var items = list.Where(d =>
                    d.Categories.Any(e => e.CategoryId == currentData.Category.CategoryId));

                    items.ForEach(d =>
                    {
                        if (!tempList.Contains(d))
                            tempList.Add(d);
                    });
                }
                list = tempList;
            }
            var data = list.ToPagedList(pageNumer, Helpers.SettingsHelper.DefaultPageSize);

            return View(data);
        }

        /// <summary>
        /// Filters this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        /// <remarks>uses PRG system - post redirect get - for users ot be able to refresh the page</remarks>
        [HttpPost]
        public async Task<ActionResult> Filter()
        {
            //get data and sort from database and return to the user
            Session["CategoryList"] = null; //clear data

            var list = (from currentKey in Request.Form.AllKeys
                        where currentKey.Contains("download-")
                        select currentKey.Replace("download-", "").Trim() into value
                        select Convert.ToInt32(value)).ToList();

            if (list.Count > 0)
            {
                //do the filtering
                var categories = await Database.CategoryRepository.GetAllAsnyc();

                var categoryList = categories
                    .Select(d => new CategoryViewModel
                    {
                        Category = d,
                        Selected = list.Contains(d.CategoryId)
                    })
                    .ToList();

                Session["CategoryList"] = categoryList;
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// returns details about download
        /// </summary>
        /// <param name="friendlyName">friendly name of the download</param>
        /// <returns>view</returns>
        [Route("details/{friendlyName}")]
        public async Task<ActionResult> Detail(string friendlyName)
        {
            var downloads = await Database.DownloadRepository.FindSingleAsync(d => d.FriendlyName == friendlyName,
                d => d.Categories);

            if (downloads == null)
            {
                SetMessage($"We can't find download with friendly name {friendlyName}");
                return RedirectToAction("Index");
            }

            return View(downloads);
        }

        /// <summary>
        /// Downloads the by identifier.
        /// </summary>
        /// <param name="downloadId">The download identifier.</param>
        /// <returns>Task&lt;ActionResult&gt;.</returns>
        [Route("{downloadId}/download")]
        public async Task<ActionResult> DownloadById(int downloadId)
        {
            var download = await Database.DownloadRepository.FindSingleAsync(d => d.DownloadId == downloadId);
            if (download == null)
            {
                SetMessage($"We can't find download with id {downloadId}");
                return RedirectToAction("Index");
            }

            //do the download
            var stream = await factory.GetFileWorker()
                .DownloadFileAsync(download.FileName);

            if (stream == null)
            {
                SetMessage("There was an error working with Azure Storage. Check logs.");
                return RedirectToAction("Index");
            }

            download.Count = download.Count + 1;

            try
            {
                Database.DownloadRepository.Update(download); //update download count
                await Database.CommitAsync();
            }
            catch (Exception err)
            {
                string message = $"Error has occurred with updating the database: {err.Message}";
                Debug.Write(message);
                SetMessage(message);
                return RedirectToAction("Index");
            }

            string contentType = "";
            switch (download.DownloadType)
            {
                case DownloadType.PDF:
                    contentType = "application/pdf";
                    break;
                case DownloadType.DOC:
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                default:
                    contentType = "application/zip, application/octet-stream";
                    break;
            }

            var memoryStream = stream as MemoryStream;
            if (memoryStream == null) throw new Exception("No data to return!");

            return File(memoryStream.ToArray(), contentType, download.FileName);
        }
    }
}