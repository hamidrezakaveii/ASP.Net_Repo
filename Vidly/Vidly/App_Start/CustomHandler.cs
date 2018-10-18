using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Vidly.App_Start
{
    public class CustomHandler : IHttpHandler
    {
        public RequestContext RequestContext { get; set; }

        public CustomHandler(RequestContext reqcon)
        {
            RequestContext = reqcon;
        }
        public bool IsReusable
        {
            //reusable handler
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            //custom logic here
            context.Response.Write("Hello from custom handler!");
        }
    }
}