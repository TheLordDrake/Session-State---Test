using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SessionSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            // If ASP MVC is being used then it is preferable to not use the actual Session
            // object from HttpContext.Current.Session but to use the new
            // HttpSessionStateWrapper& HttpSessionStateBase from System.Web.Abstractions.dll
            // then use a Factory or DI to get the Session.
            // https://stackoverflow.com/questions/560084/session-variables-in-asp-net-mvc/560115#comment372807_560115

            var sessionWrapper = new HttpSessionStateWrapper(HttpContext.Current.Session)
            {
                { "DoNotTrack", true }
            };
        }
    }
}
