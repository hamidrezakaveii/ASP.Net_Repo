using Jour3_HtmlHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour3_HtmlHelper.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register/Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // POST: Register/Save
        public ActionResult Save(Student std)
        {
            //Envoyer information dans la BD
            Student myStudent = new Student();
            myStudent.StudentName = std.StudentName;
            //myStudent.Age = std.Age;
            myStudent.Description = std.Description;
            myStudent.StudentGender = std.StudentGender;
            myStudent.IsNewlyEnrolled = std.IsNewlyEnrolled;


            return View("ConfirmerSave", myStudent);
        }
    }
}