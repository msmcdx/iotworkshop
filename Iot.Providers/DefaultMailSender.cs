using System.Threading.Tasks;
using Iot.Interfaces;

namespace Iot.Providers
{
    /// <summary>
    /// Class DefaultMailSender.
    /// </summary>
    public class DefaultMailSender : IMailer
    {
        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="to">To.</param>
        /// <param name="from">From.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="content">The content.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<bool> SendEmailAsync(string to, string @from, string subject, string content)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        public string Server { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the default mail to.
        /// </summary>
        /// <value>The default mail to.</value>
        public string DefaultMailTo { get; set; }
    }
}