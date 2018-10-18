using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.App_Start;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //route for CustomHandler 
            //routes.Add(new Route("Home/Custom", new CustomRouteHandler()));


            routes.MapRoute(
                "EditMovie",
                "Movies/Edit/{id}",
                new { controller = "Movies", action = "Edit", MovieId = "id" }
                );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
