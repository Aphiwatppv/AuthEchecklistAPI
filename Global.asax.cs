using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using MySqlEngineServiceAuthen.MySqlServiceAuthen;
using MySqlEngineServiceAuthen.MySqlAccess;
using Unity.Injection;
using System.Configuration;
using Unity.AspNet.WebApi;
//using Unity.Mvc5;

namespace AuthEchecklistAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterComponents(); 
        }

        private void RegisterComponents()
        {
            var container = new UnityContainer();

            string connectionString = ConfigurationManager.ConnectionStrings["AccountDb"].ConnectionString;
            container.RegisterType<IMySqlAccess, MySqlAccess>(
                new InjectionConstructor(connectionString));
            container.RegisterType<IMySqlServiceAuthen, MySqlServiceAuthen>();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.AspNet.WebApi.UnityDependencyResolver(container);
        }

    }
}
