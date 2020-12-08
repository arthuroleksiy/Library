using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Task24_advanced
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Questionnary",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Questionnary", action = "MakeForm", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DetailedArticle",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DetailedArticle", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ByGenre",
                url: "{Genre}",
                defaults: new { controller = "Home", action = "ActionByGenre" });

            routes.MapRoute(
                name: "ByOrder",
                url: "{Order}",
                defaults: new { controller = "Home", action = "ActionByOrder" });

            
        }
    }
}
