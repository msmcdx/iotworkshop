using System.Linq;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Iot.Data.EF;
using Iot.Engine;
using Iot.Interfaces;
using Microsoft.Practices.Unity.Mvc;

namespace IoT.Web
{
    /// <summary>
    /// Class UnityConfig.
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registers the components.
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            
            //register container
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            //register my types
            container.RegisterType<IConfigurationFactory, ConfigurationFactory>();
            container.RegisterType<IIotUOW, IotUow>();
            container.RegisterInstance(GlobalConfiguration.Configuration);
            container.RegisterType<ICacheService, InMemoryCache>();

            //register web api
            GlobalConfiguration.Configuration.DependencyResolver = 
                new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}