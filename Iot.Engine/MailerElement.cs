using System.Configuration;

namespace Iot.Engine
{
    /// <summary>
    /// Class MailerElement, which is required for setting the configuration for doing mailing options
    /// </summary>
    public class MailerElement : ConfigurationElement
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
        [ConfigurationProperty("server")]
        public string Server { get { return (string)base["server"]; } set { base["server"] = value; } }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        [ConfigurationProperty("username", IsRequired = true)]
        public string Username { get { return (string)base["username"]; } set { base["username"] = value; } }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [ConfigurationProperty("password", IsRequired = true)]
        public string Password { get { return (string)base["password"]; } set { base["password"] = value; } }

        /// <summary>
        /// Gets or sets the default mail to.
        /// </summary>
        /// <value>The default mail to.</value>
        [ConfigurationProperty("defaultMailTo", IsRequired = true)]
        public string DefaultMailTo { get { return (string)base["defaultMailTo"]; } set { base["defaultMailTo"] = value; } }
    }
}