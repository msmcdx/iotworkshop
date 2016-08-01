using System.Web.Http;
using Iot.Data.EF;

namespace IoT.Web.Base
{
    /// <summary>
    /// Class BaseApiController - base api controller for working with database
    /// </summary>
    public abstract class BaseApiController : ApiController
    {
        /// <summary>
        /// The uow
        /// </summary>
        private readonly IotUow uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataController" /> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        protected BaseApiController(IotUow uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// The database
        /// </summary>
        /// <value>The database.</value>
        protected IotUow Database => uow;
    }
}