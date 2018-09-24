using Jour3_HtmlHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour3_HtmlHelper.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        // POST: Account/Register
        [HttpPost]
        public ContentResult Register()
        {

            Student myStudent = new Student();

            myStudent.StudentName = Request.Form["Name"];
            myStudent.StudentGender = Request.Form["Gender"];
            myStudent.IsNewlyEnrolled = Boolean.Parse(Request.Form["IsNewlyEnrolled"]);

            return Content(myStudent.ToString());
        }
    }
}