using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace IoT.Web.Infrastrcture
{
    /// <summary>
    /// Class RssActionResult, which represents an option to provide rss output
    /// </summary>
    public class RssActionResult : ActionResult
    {
        /// <summary>
        /// Gets or sets the feed.
        /// </summary>
        /// <value>The feed.</value>
        public SyndicationFeed Feed { get; set; }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            var rssFormatter = new Rss20FeedFormatter(Feed);
            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                rssFormatter.WriteTo(writer);
            }
        }
    }
}