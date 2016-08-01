namespace Iot.Models
{
    /// <summary>
    /// Class PushNotificationTemplateType.
    /// </summary>
    public class PushNotificationTemplateType
    {
        /// <summary>
        /// Gets or sets the push notification template type identifier.
        /// </summary>
        /// <value>The push notification template type identifier.</value>
        public int PushNotificationTemplateTypeId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
    }
}