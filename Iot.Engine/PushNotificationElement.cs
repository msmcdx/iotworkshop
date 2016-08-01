using System.Configuration;

namespace Iot.Engine
{
    /// <summary>
    /// Class PushNotificationElement.
    /// </summary>
    public class PushNotificationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name { get { return (string)base["name"]; } set { base["name"] = value; } }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [ConfigurationProperty("type", IsKey = true, IsRequired = true)]
        public string Type { get { return (string)base["type"]; } set { base["type"] = value; } }

        /// <summary>
        /// Gets or sets the full access namespace.
        /// </summary>
        /// <value>The full access namespace.</value>
        [ConfigurationProperty("fullAccessNamespace", IsRequired = false)]
        public string FullAccessNamespace { get { return (string)base["fullAccessNamespace"]; } set { base["fullAccessNamespace"] = value; } }


        /// <summary>
        /// Gets or sets the name of the hub.
        /// </summary>
        /// <value>The name of the hub.</value>
        [ConfigurationProperty("hubName", IsRequired = false)]
        public string HubName { get { return (string)base["hubName"]; } set { base["hubName"] = value; } }
    }
}