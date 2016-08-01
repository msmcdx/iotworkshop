using System.Web.Mvc;
using IoT.Web.Helpers;

namespace IoT.Web.Base
{
    /// <summary>
    /// Class DefaultController.
    /// </summary>
    public abstract class DefaultController : Controller
    {
        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <param name="title">The title.</param>
        public virtual void SetTitle(string title="")
        {
            ViewBag.Title = title;
        }

        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public virtual void SetMessage(string message)
        {
            TempData[ConstantHelper.PageMessageKey] = message;
        }
    }
}