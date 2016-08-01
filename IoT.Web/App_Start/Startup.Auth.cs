using IoT.Web.Helpers;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace IoT.Web
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        /// <summary>
        /// Configures the authentication.
        /// </summary>
        /// <param name="app">The application.</param>
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = ConstantHelper.ClientId,
                    Authority = ConstantHelper.Authority,
                    PostLogoutRedirectUri = ConstantHelper.PostLogoutRedirectUri
                });
        }
    }
}
