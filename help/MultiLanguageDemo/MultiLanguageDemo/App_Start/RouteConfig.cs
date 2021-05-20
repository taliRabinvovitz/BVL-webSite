﻿using System.Web.Mvc;
using System.Web.Routing;

namespace MultiLanguageDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "LocalizedDefault",
               url: "{lang}/{controller}/{action}",
               defaults: new { controller = "Home", action = "Index"},
               constraints: new {lang="es-es|fr-fr|en-us"}
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", lang = "en-us" }
            );
        }
    }
}
