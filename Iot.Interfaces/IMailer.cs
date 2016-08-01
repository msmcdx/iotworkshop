using System.Threading.Tasks;

namespace Iot.Interfaces
{
    /// <summary>
    /// Interface IMailer, which enables us to send emails
    /// </summary>
    public interface IMailer
    {
        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="to">To person.</param>
        /// <param name="from">From person.</param>
        /// <param name="subject">subject of the email</param>
        /// <param name="content">The content.</param>
        /// <returns><c>true</c>, if sending an email succeed, or <c>false</c> otherwise</returns>
        Task<bool> SendEmailAsync(string to, string from, string subject, string content);
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        string Server { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        string Password { get; set; }
        /// <summary>
        /// Gets or sets the default mail to.
        /// </summary>
        /// <value>The default mail to.</value>
        string DefaultMailTo { get; set; }
    }
}