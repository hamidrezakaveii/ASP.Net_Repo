using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Gestion_Des_Conges_2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "GET,PUT,POST,DELETE"));
        }
    }
}
