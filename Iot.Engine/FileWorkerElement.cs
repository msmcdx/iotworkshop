using System.Configuration;

namespace Iot.Engine
{
    /// <summary>
    /// Class FileWorkerElement.
    /// </summary>
    public class FileWorkerElement : ConfigurationElement
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
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        [ConfigurationProperty("rootPath", IsRequired = true)]
        public string RootPath { get { return (string)base["rootPath"]; } set { base["rootPath"] = value; } }

        /// <summary>
        /// Gets or sets the account key.
        /// </summary>
        /// <value>The account key.</value>
        [ConfigurationProperty("accountKey", IsRequired = false)]
        public string AccountKey { get { return (string)base["accountKey"]; } set { base["accountKey"] = value; } }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        [ConfigurationProperty("accountName", IsRequired = false)]
        public string AccountName { get { return (string)base["accountName"]; } set { base["accountName"] = value; } }
    }
}