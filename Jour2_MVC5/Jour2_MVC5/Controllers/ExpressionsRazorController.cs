using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour2_MVC5.Controllers
{
    public class ExpressionsRazorController : Controller
    {
        // GET: ExpressionsRazor
        public ActionResult ExpressionsRazor()
        {
            ViewBag.Message = "Ceci est un message dynamique";
            ViewBag.total = 25;
            return View();
        }
    }
}