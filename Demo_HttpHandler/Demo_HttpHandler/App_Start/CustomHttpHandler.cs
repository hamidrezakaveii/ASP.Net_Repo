using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Demo_HttpHandler.App_Start
{
    public class CustomHttpHandler : IHttpHandler
    {
        RequestContext RequestContext;

        public CustomHttpHandler(RequestContext reqcon)
        {
            RequestContext = reqcon;
        }


        public bool IsReusable
        {   
            //reusble request
            get{ return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Message from Custom Handler");
        }
    }
}