using System.Web;
using System.Web.Mvc;

namespace IoT.Web.Controllers
{
    /// <summary>
    /// Class AccountController.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Signs the out.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult SignOut()
        {
            if (Request.IsAuthenticated)
                HttpContext.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}