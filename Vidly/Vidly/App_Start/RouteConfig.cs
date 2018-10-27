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

            //Enable MVC attribute Routes
            routes.MapMvcAttributeRoutes();


            //route for CustomHandler 
            //routes.Add(new Route("Home/Custom", new CustomRouteHandler()));

            //Customs route
            //routes.MapRoute("MoviesByByReleasedDate",
            //    "movies/released/{year}/{month}",
            //    new { controller = "movies", action = "ByReleasedDate" },
            //    new { year = @"2017|2018", month = @"\d{2}" }
            //    );

            //Customs route
            routes.MapRoute(
                "EditMovie",
                "Movies/Edit/{movieId}",
                new { controller = "Movies", action = "Edit" }
                );





            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
