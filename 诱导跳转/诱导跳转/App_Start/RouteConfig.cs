using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace 诱导跳转
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "{uid}-{pid}",
                defaults: new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}/{uid}-{pid}",
                defaults: new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}