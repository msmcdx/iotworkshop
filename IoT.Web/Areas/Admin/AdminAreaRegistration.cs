using System.Web.Mvc;

namespace IoT.Web.Areas.Admin
{
    /// <summary>
    /// Class AdminAreaRegistration.
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the name of the area.
        /// </summary>
        /// <value>The name of the area.</value>
        public override string AreaName => "Admin";

        /// <summary>
        /// Registers the area.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}