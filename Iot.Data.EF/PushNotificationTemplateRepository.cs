using System.Data.Entity;
using Iot.Interfaces;
using Iot.Models;

namespace Iot.Data.EF
{
    /// <summary>
    /// Class PushNotificationTemplateRepository.
    /// </summary>
    public class PushNotificationTemplateRepository : DataRepository<PushNotificationTemplate>,IPushNotificationTemplateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRepository{T}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        public PushNotificationTemplateRepository(DbContext context) : base(context)
        {
        }
    }
}