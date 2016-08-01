namespace Iot.Models
{
    /// <summary>
    /// Class PushNotificationTemplate.
    /// </summary>
    public class PushNotificationTemplate
    {
        /// <summary>
        /// Gets or sets the push notification template identifier.
        /// </summary>
        /// <value>The push notification template identifier.</value>
        public int PushNotificationTemplateId { get; set; }
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
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the push notification template type identifier.
        /// </summary>
        /// <value>The push notification template type identifier.</value>
        public int PushNotificationTemplateTypeId { get; set; }
        /// <summary>
        /// Gets or sets the type of the push notification template.
        /// </summary>
        /// <value>The type of the push notification template.</value>
        public PushNotificationTemplateType PushNotificationTemplateType { get; set; }
        /// <summary>
        /// Gets or sets the type of the push notification.
        /// </summary>
        /// <value>The type of the push notification.</value>
        public PushNotificationType PushNotificationType { get; set; }
    }

    /// <summary>
    /// Enum PushNotificationType
    /// </summary>
    public enum PushNotificationType
    {
        /// <summary>
        /// The toast
        /// </summary>
        TOAST = 0,
        /// <summary>
        /// The raw
        /// </summary>
        RAW,
        /// <summary>
        /// The livetile
        /// </summary>
        LIVETILE
    }
}