using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion_Des_Conges.Models;

namespace Gestion_Des_Conges.Controllers
{
    public class HomeController : Controller
    {

        // Variables definition
        UserContextEntities context = new UserContextEntities();


        public enum Grade
        {
            Employee,
            Manager,
            Admin
        }


        public enum Sex
        {
            Male = 'M',
            Female = 'F'
        }

        // GET: Home
        public ActionResult Index()
        {



            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Login(Login login)
        {
            string msg = "";

            string email = login.Email;
            string pass = login.Password;

            

            var query = context.LMEmployees.Where(c => c.Email == email && c.Pass == pass).FirstOrDefault();

            //string test = query.ToString();

            if (query != null)
            {
                msg = "Welcome";
            }
            else
            {

                //RedirectToAction("Login", "Home", FormMethod.Get);
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }


            return Content(msg);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.Grade= new SelectList(Enum.GetValues(typeof(Grade)), Grade.Employee);
            ViewBag.Sex = new SelectList(Enum.GetValues(typeof(Sex)), Sex.Male);
            //ViewBag.Grade = new SelectList(Enum.GetValues(typeof(Grade)), Grade.Employee);

            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var employee = new LMEmployee()
                {
                    EmpId = Convert.ToInt32(collection.Get("EmpId")),
                    EmpFName = collection.Get("EmpFName"),
                    EmpLName = collection.Get("EmpLName"),
                    DateOfBirth = Convert.ToDateTime(collection.Get("DateOfBirth")),
                    ManagerEmpId = Convert.ToInt32(collection.Get("ManagerEmpId")),
                    Grade = collection.Get("Grade"),
                    Sex = collection.Get("Sex"),
                    Tel = collection.Get("Tel"),
                    SickLeaveBalance = Convert.ToInt32(collection.Get("SickLeaveBalance")),
                    EarnedLeaveBalance = Convert.ToInt32(collection.Get("EarnedLeaveBalance")),
                    Email = collection.Get("Email"),
                    Pass = collection.Get("Pass")



                };

                //context.Add(employee);
                context.LMEmployees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
