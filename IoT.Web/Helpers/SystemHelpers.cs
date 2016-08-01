using System.Text.RegularExpressions;
using System.Web;

namespace IoT.Web.Helpers
{
    /// <summary>
    /// helper for web related stuff
    /// </summary>
    public class SystemHelpers
    {
        /// <summary>
        /// get full HTTP path to the app
        /// </summary>
        /// <returns>pat to the app or null otherwise</returns>
        /// <remarks>http://appname/call</remarks>
        public static string GetApplicationHTTPPath()
        {
            string appPath = null;

            HttpContext context = HttpContext.Current;

            //is there a valid request
            if (context != null)
            {
                //format the output (add port, if not 80)
                appPath =
                    $"{context.Request.Url.Scheme}://{context.Request.Url.Host}" +
                    $"{(context.Request.Url.Port == 80 ? string.Empty : ":" + context.Request.Url.Port)}" +
                    $"{context.Request.ApplicationPath}";
            }
            return appPath;
        }

        /// <summary>
        /// Get the current users IP address
        /// </summary>
        /// <returns>user ip address or null otherwise</returns>
        public static string GetUsersIpAddress()
        {
            var context = HttpContext.Current;
            var serverName = context.Request.ServerVariables["SERVER_NAME"];
            if (serverName.ToLower().Contains("localhost"))
            {
                return serverName;
            }
            var ipList = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            return !string.IsNullOrEmpty(ipList) ? ipList.Split(',')[0] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        /// <summary>
        /// Determines whether is valid email of the specified input email.
        /// </summary>
        /// <param name="inputEmail">The input email.</param>
        /// <returns><c>true</c> if is valid email the specified input email; otherwise, <c>false</c>.</returns>
        public static bool IsValidEmail(string inputEmail)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            return re.IsMatch(inputEmail);
        }
    }
}