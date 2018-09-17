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

        // GET: InfoRequest
        public ActionResult InfoRequest()
        {
            return View();
        }

        
        // GET: ListNoms
        public ActionResult ListNoms()
        {
            string[] teamMembers = { "Matt", "Leila", "Ahmed", "Andre" };
            ViewBag.listNoms = teamMembers;
            return View();
        }

        // GET: LeapYear
        public ActionResult LeapYear()
        {
            return View();
        }
    }
}