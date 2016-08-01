using System.Net.Http.Formatting;
using System.Web.Http;

namespace IoT.Web
{
    /// <summary>
    /// Class WebApiConfig.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Clear();
            //add only json to the calls
            config.Formatters.Add(new JsonMediaTypeFormatter());

            //disable self reference errors
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
               Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
