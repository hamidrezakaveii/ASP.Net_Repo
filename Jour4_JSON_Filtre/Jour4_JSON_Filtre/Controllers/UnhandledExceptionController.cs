using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour4_JSON_Filtre.Controllers
{
    [HandleError]
    public class UnhandledExceptionController : Controller
    {
        // GET: UnhandledException
        public ActionResult Index()
        {

            //throw new Exception("This is unhandled exception");

            return View();
        }
    }
}