using Iot.Data.EF;

namespace IoT.Web.Base
{
    /// <summary>
    /// Class BaseDataController, where the default implementation lives
    /// </summary>
    public abstract class BaseDataController : DefaultController
    {
        /// <summary>
        /// The uow
        /// </summary>
        private readonly IotUow uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseDataController"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        protected BaseDataController(IotUow uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// The database
        /// </summary>
        protected IotUow Database => uow;
    }
}