using System;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Web.Mvc;
using Iot.Data.EF;
using Iot.Engine;
using Iot.Interfaces;
using IoT.Web.Base;
using IoT.Web.Helpers;
using IoT.Web.Infrastrcture;
using IoT.Web.ViewModels;

namespace IoT.Web.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// </summary>
    public class HomeController : BaseDataController
    {
        #region CTOR

        /// <summary>
        /// The configuration factory
        /// </summary>
        private readonly IConfigurationFactory configurationFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        /// <param name="configurationFactory">The configuration factory.</param>
        public HomeController(IotUow uow, IConfigurationFactory configurationFactory) : base(uow)
        {
            this.configurationFactory = configurationFactory;
        }

        #endregion

        /// <summary>
        /// shows the homepage
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Abouts the whole project.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult About()
        {
            return View(new AboutViewModel());
        }

        /// <summary>
        /// Abouts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task&lt;RedirectToRouteResult&gt;.</returns>
        [HttpPost]
        public async Task<ActionResult> About(AboutViewModel model)
        {
            //server side checking
            if (string.IsNullOrEmpty(model.Email))
            {
                SetMessage("Email is required field!");
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Content
                .Replace(Environment.NewLine, "")
                .TrimEnd()
                .TrimStart()
                ))
            {
                SetMessage("Content is required field!");
                return View(model);
            }

            //send email
            IMailer mailer = configurationFactory.GetMailer();

            await mailer.SendEmailAsync(mailer.DefaultMailTo,
                model.Email,
                "Question / comment from IOT workshop",
                model.Content);

            SetMessage("Your inquiry or comment has been successfully submited!");

            return RedirectToAction("About");
        }

        /// <summary>
        /// get devices rss
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult DevicesRss()
        {
            var list = Database.DeviceRepository
                .GetAll().ToList();

            var currentItems = list.Select(d =>
                    new SyndicationItem(d.Name, d.Description,
                        new Uri($"{SystemHelpers.GetApplicationHTTPPath()}/devices/device/{d.DeviceId}",
                            UriKind.RelativeOrAbsolute)));


            var alternateLink = new Uri(SystemHelpers.GetApplicationHTTPPath(), 
                UriKind.RelativeOrAbsolute);

            var currentProductsFeed = new SyndicationFeed("Iot workshop devices RSS",
                "this is a rss to get all devices by rss",
                alternateLink) {Items = currentItems.AsEnumerable()};


            return new RssActionResult
            {
                Feed = currentProductsFeed
            };
        }

        /// <summary>
        /// get items rss
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ItemsRss()
        {
            var list = Database.ItemRepository.GetAll().ToList();

            var currentItems = list.Select(d =>
                new SyndicationItem(d.Device.Name,
                    d.TimeAdded.ToString(CultureInfo.InvariantCulture),
                    new Uri($"{SystemHelpers.GetApplicationHTTPPath()}/item/{d.DeviceId}/byid",
                        UriKind.RelativeOrAbsolute)));

            //get feed for items
            var currentProductsFeed = new SyndicationFeed("Iot workshop items RSS",
                "this is a rss to get all items by rss",
                new Uri(SystemHelpers.GetApplicationHTTPPath(), UriKind.RelativeOrAbsolute)) {Items = currentItems};


            return new RssActionResult
            {
                Feed = currentProductsFeed
            };
        }
    }
}