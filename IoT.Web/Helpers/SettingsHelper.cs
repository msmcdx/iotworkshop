using System;
using System.Web.Configuration;

namespace IoT.Web.Helpers
{
    /// <summary>
    /// Class SettingsHelper for helping with configuration file.
    /// </summary>
    public static class SettingsHelper
    {
        /// <summary>
        /// The default page size
        /// </summary>
        public static int DefaultPageSize = Convert.ToInt32(WebConfigurationManager.AppSettings["DefaultPageSize"]);
    }
}