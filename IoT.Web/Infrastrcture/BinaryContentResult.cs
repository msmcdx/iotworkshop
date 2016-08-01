using System.IO;
using System.Web;
using System.Web.Mvc;

namespace IoT.Web.Infrastrcture
{
    /// <summary>
    /// Class BinaryContentResult, which return binary content as a result
    /// </summary>
    public class BinaryContentResult : ActionResult
    {
        /// <summary>
        /// The content type
        /// </summary>
        private readonly string ContentType;
        /// <summary>
        /// The content bytes
        /// </summary>
        private readonly byte[] ContentBytes;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryContentResult"/> class.
        /// </summary>
        /// <param name="contentBytes">The content bytes.</param>
        /// <param name="contentType">Type of the content.</param>
        public BinaryContentResult(byte[] contentBytes, string contentType)
        {
            this.ContentBytes = contentBytes;
            this.ContentType = contentType;
        }

        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.ContentType = this.ContentType;

            var stream = new MemoryStream(this.ContentBytes);
            stream.WriteTo(response.OutputStream);
            stream.Dispose();
        }
    }

}