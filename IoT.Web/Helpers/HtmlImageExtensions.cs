using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IoT.Web.Helpers
{
    /// <summary>
    /// Class HtmlImageExtensions.
    /// </summary>
    /// <remarks>
    ///     based on http://www.asp.net/mvc/overview/older-versions-1/views/using-the-tagbuilder-class-to-build-html-helpers-cs
    /// </remarks>
    public static class HtmlImageExtensions
    {
        /// <summary>
        /// Images the specified helper.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="url">The URL.</param>
        /// <param name="alternateText">The alternate text.</param>
        /// <returns>System.String.</returns>
        public static MvcHtmlString Image(this HtmlHelper helper, 
            string id, 
            string url, 
            string alternateText)
        {
            return Image(helper, id, url, alternateText, null);
        }

        /// <summary>
        /// Images the specified helper.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="url">The URL.</param>
        /// <param name="alternateText">The alternate text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>System.String.</returns>
        public static MvcHtmlString Image(this HtmlHelper helper, 
            string id, 
            string url, 
            string alternateText,
            object htmlAttributes)
        {
            // Create tag builder
            var builder = new TagBuilder("img");

            // Create valid id
            builder.GenerateId(id);

            // Add attributes
            builder.MergeAttribute("src", $"{SystemHelpers.GetApplicationHTTPPath()}/{url}");
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}