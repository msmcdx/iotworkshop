using System.Web.Http;
using System.Web.Mvc;

namespace IoT.Web.Areas.HelpPage
{
    /// <summary>
    /// Class HelpPageAreaRegistration.
    /// </summary>
    public class HelpPageAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Gets the name of the area.
        /// </summary>
        /// <value>The name of the area.</value>
        public override string AreaName => "HelpPage";

        /// <summary>
        /// Registers the area.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "HelpPageModel",
                url: "help/ResourceModel/{modelName}",
                defaults: new { controller = "Help", action = "ResourceModel"}
            );

            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}