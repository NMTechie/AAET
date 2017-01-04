using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CAAAETConfigurationUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");           
            routes.MapRoute(
                name: "CAAAETGridRoutingMap",
                url: "ConfigurationUIGridBehaviour/{controller}/{action}/{id}",
                defaults: new { controller = "Search", action = "SearchResult", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "CAAAETDefaultRoutingMap",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "CAAAETDefault", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}