using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ChickenCoop
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {

            routes.Ignore("{resource}.axd/{*pathInfo}");

            //non-admin routes
            routes.MapPageRoute("Home", "Home", "~/Default.aspx");
            routes.MapPageRoute("Coop-Camera", "Coop Camera", "~/cam.aspx");
            routes.MapPageRoute("Coop-Door", "Coop Door", "~/door.aspx");
            routes.MapPageRoute("Coop-Login", "Coop Login", "~/login.aspx");

        }
    }
}