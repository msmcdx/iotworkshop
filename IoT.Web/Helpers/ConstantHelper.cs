using System.Configuration;

namespace IoT.Web.Helpers
{
    /// <summary>
    /// Class ConstantHelper for helper messages
    /// </summary>
    public static class ConstantHelper
    {
        /// <summary>
        /// The page message key
        /// </summary>
        public const string PageMessageKey = "PageMessage";
        /// <summary>
        /// The push notification unique tag
        /// </summary>
        public const string PushNotificationUniqueTag = "deviceName:";
        /// <summary>
        /// The client identifier
        /// </summary>
        public static readonly string ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
        /// <summary>
        /// The push notification string
        /// </summary>
        public static readonly string PushNotificationString = ConfigurationManager.AppSettings["PushNotificationString"];
        /// <summary>
        /// The push notification hub name
        /// </summary>
        public static readonly string PushNotificationHubName = ConfigurationManager.AppSettings["PushNotificationHubName"];
        /// <summary>
        /// The aad instance
        /// </summary>
        public static readonly string AadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        /// <summary>
        /// The tenant identifier
        /// </summary>
        public static readonly string TenantId = ConfigurationManager.AppSettings["ida:TenantId"];
        /// <summary>
        /// The post logout redirect URI
        /// </summary>
        public static readonly string PostLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
        /// <summary>
        /// The authority
        /// </summary>
        public static readonly string Authority = AadInstance + TenantId;
    }
}