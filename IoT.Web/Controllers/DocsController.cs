using System.Web.Mvc;
using IoT.Web.Base;

namespace IoT.Web.Controllers
{
    /// <summary>
    /// Class DocsController - logic for documentation and workshop start
    /// </summary>
    public class DocsController : DefaultController
    {
        /// <summary>
        /// shows the homepage of the docs and starting point of workshop
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// shows the web part of the workshop
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult WebPart()
        {
            return View();
        }

        /// <summary>
        /// Desktops this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Desktop()
        {
            return View();
        }

        /// <summary>
        /// Iots this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Iot()
        {
            return View();
        }
    }
}