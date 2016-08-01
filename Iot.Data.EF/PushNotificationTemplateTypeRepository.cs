using System.Data.Entity;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class PushNotificationTemplateTypeRepository.
    /// </summary>
    public class PushNotificationTemplateTypeRepository : DataRepository<PushNotificationTemplateType>,IPushNotificationTemplateTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public PushNotificationTemplateTypeRepository(DbContext context) : base(context)
        {
        }
    }
}