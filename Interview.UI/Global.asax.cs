using Interview.Service;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Interview.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        [Obsolete]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LogManager.LoadConfiguration(Server.MapPath("~/NLog.config"));
            GlobalFilters.Filters.Add(new MyHandleErrorAttribute());
            DependencyConfiguration.RegisterDependencies();
      }
        public void Application_Error()
        {
            // Log unhandled exceptions
            var exception = Server.GetLastError();
            LogManager.GetCurrentClassLogger().Error(exception, "Unhandled exception");
            Server.ClearError();
            Response.Redirect("Error");
        }
      
    }
}
