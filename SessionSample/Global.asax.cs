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
            // Create Cookie
            var cookie = new HttpCookie("SampleTrackingCookie") {["DoNotTrack"] = "true"};

            // Set Cookie TTL, defaults to non-persistent if not set
            cookie.Expires = DateTime.Now.AddHours(1);

            // Write cookie to client
            Response.Cookies.Add(cookie);
        }
    }
}
