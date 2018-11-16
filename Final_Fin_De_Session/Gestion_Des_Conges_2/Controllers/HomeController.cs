using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gestion_Des_Conges_2.Models;

namespace Gestion_Des_Conges_2.Controllers
{
    public class HomeController : Controller
    {

        // Definition des variables
        UserContextEntities context = new UserContextEntities();


        public enum Grade
        {
            Employee,
            Manager,
            Admin
        }


        public enum Sex
        {
            Male,
            Female
        }

        public enum Manager
        {
                
        }

        [Authorize]
        public ActionResult Index()
        {



            return View();
        }


        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();


            return Redirect("/Home/Index");
        }


        //[HttpGet]
        //public ActionResult Login()
        //{

        //    return View();
        //}


        //[HttpPost]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Login(Login login, string ReturnUrl)
        {


            //string test = query.ToString();

            //if (query != null)
            //{
            //    msg = "Welcome";
            //    Session["id"] = query.EmpId;
            //    Session["fname"] = query.EmpFName;
            //    Session["lname"] = query.EmpLName;

            //}
            //else
            //{

            //    RedirectToAction("Login", "Home", FormMethod.Get);
            //    return Redirect(Request.UrlReferrer.PathAndQuery);    //redirect de la meme page si il n'y pas de resultat
            //}
            string msg = "";

            http://localhost:12138/api/Report/ListEmployeesif (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {


                    string email = login.Email;
                    string pass = login.Password;



                    var query = context.LMEmployees.Where(c => c.Email == email && c.Pass == pass).FirstOrDefault();


                    if (query != null)
                    {
                        //msg = "Welcome";
                        //Session["id"] = query.EmpId;
                        //Session["fname"] = query.EmpFName;
                        //Session["lname"] = query.EmpLName;


                        var profileData = new UserProfileSessionData
                        {
                            UserId = query.EmpId,
                            EmailAddress = query.Email,
                            FullName = query.EmpFName + " " + query.EmpLName
                        };


                        FormsAuthentication.SetAuthCookie(query.Email, false);

                        this.Session["UserProfile"] = profileData;
                        //this.Session["Users"] = "access";


                        //return Redirect("/Home/LeaveRequest");
                        return Redirect(ReturnUrl);

                    }
                    else
                    {

                        //RedirectToAction("Login", "Home", FormMethod.Get);
                        //return Redirect(Request.UrlReferrer.PathAndQuery); //redirect de la meme page si il n'y pas de resultat
                        msg = "Email and/or Password are incorrect or does not exist.";
                        return View(login);
                    }

                }
                else
                {
                    //return Redirect(Request.UrlReferrer.PathAndQuery);
                    return View(login);
                }
            }
            //else
            //{
            //    return View();
            //}



            return View();
        }


        [Authorize(Roles = "Employee, Manager")]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult LeaveRequest(FormCollection collection)
        {


            ViewData["uname"] = User.Identity.Name;


            if (Request.HttpMethod == "POST")
            {

                var leaveRequest = new LMLeaveHistory()
                {
                    LeaveId = Convert.ToInt32(collection.Get("LeaveId")),
                    EmpId = Convert.ToInt32(collection.Get("EmpId")),
                    ApplicationDate = Convert.ToDateTime(collection.Get("ApplicationDate")),
                    LeaveStartDate = Convert.ToDateTime(collection.Get("LeaveStartDate")),
                    LeaveEndDate = Convert.ToDateTime(collection.Get("LeaveEndDate")),
                    LeaveType = collection.Get("LeaveType"),
                    LeaveDesc = collection.Get("LeaveDesc"),
                    LeaveState = collection.Get("LeaveState"),
                    StateReason = ""


                };

                context.LMLeaveHistories.Add(leaveRequest);
                var result = context.SaveChanges();

                if (result == 1)
                {
                    ViewData["action"] = "The request was transfered successfully.";
                }
                else
                {
                    ViewData["action"] = "The is a problem, please contact the administrator.";
                }

            }

            

                return View();
        }



        [Authorize(Roles = "Employee, Manager")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RequestList()
        {
            //var requestList =
            //    context.LMLeaveHistories.Join(context.LMEmployees, l => l.EmpId, e => e.EmpId, (l, e) => new { EmployeeId = l.EmpId, EmployeeEmail = e.Email }).Where( x => x.EmployeeEmail == User.Identity.Name).FirstOrDefault().EmployeeId;
            var employeeId = context.LMEmployees.Where(e => e.Email == User.Identity.Name).FirstOrDefault().EmpId;

            var requestList = context.LMLeaveHistories.Where(l => l.EmpId == employeeId);





            return View(requestList);
        }


        [Authorize(Roles = "Manager")]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult RequestCheck()
        {

            var managerId = context.LMEmployees.Where(e => e.Email == User.Identity.Name).FirstOrDefault().EmpId;

            var employeesId = context.LMEmployees.Where(e => e.ManagerEmpId == managerId).Select(r => r.EmpId).ToArray();


            //var requestCheckList = context.LMLeaveHistories
            //    .Join(context.LMEmployees, l => l.EmpId, e => e.EmpId, (l, e) => new {l, e})
            //    .Where(j => j.l.LeaveState == "Requested" && j.e.ManagerEmpId == managerId);


            var requestCheckList = new List<LMLeaveHistory>();


            foreach (var i in employeesId)
            {
                //requestCheckList.Add(context.LMLeaveHistories.Where(l => l.LeaveState == "Requested" && l.EmpId == i);
                var myquery = context.LMLeaveHistories.Where(l => l.LeaveState == "Requested" && l.EmpId == i);

                foreach (var item in myquery)
                {
                    requestCheckList.Add(new LMLeaveHistory()
                        {
                            LeaveId = item.LeaveId,
                            EmpId = item.EmpId,
                            ApplicationDate = item.ApplicationDate,
                            LeaveStartDate = item.LeaveStartDate,
                            LeaveEndDate = item.LeaveEndDate,
                            LeaveType = item.LeaveType,
                            LeaveDesc = item.LeaveDesc,
                            LeaveState = item.LeaveState,
                            StateReason = item.StateReason
                        }
                        
                        );
                }
            }

            return View(requestCheckList);
        }



        [Authorize(Roles = "Manager")]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult RequestCheckEdit(int? id,FormCollection collection)
        {


            var verifyItem = context.LMLeaveHistories.Where(l => l.LeaveId == id).FirstOrDefault();

            if (Request.HttpMethod == "POST")
            {
                var leaveHistory = new LMLeaveHistory()
                {
                    LeaveId = Convert.ToInt32(collection.Get("LeaveId")),
                    EmpId = Convert.ToInt32(collection.Get("EmpId")),
                    ApplicationDate = Convert.ToDateTime(collection.Get("ApplicationDate")),
                    LeaveStartDate = Convert.ToDateTime(collection.Get("LeaveStartDate")),
                    LeaveEndDate = Convert.ToDateTime(collection.Get("LeaveEndDate")),
                    LeaveType = collection.Get("LeaveType"),
                    LeaveDesc = collection.Get("LeaveDesc"),
                    LeaveState = collection.Get("LeaveState"),
                    StateReason = collection.Get("StateReason")
                };

                context.LMLeaveHistories.AddOrUpdate(leaveHistory);
                context.SaveChanges();


                return RedirectToAction("RequestCheck");
            }







            return View(verifyItem);
        }


        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Grade = new SelectList(Enum.GetValues(typeof(Grade)), Grade.Employee);
            ViewBag.Sex = new SelectList(Enum.GetValues(typeof(Sex)), Sex.Male);
            //ViewBag.Grade = new SelectList(Enum.GetValues(typeof(Grade)), Grade.Employee);

            //var queryManager = context.LMEmployees.Where(e => e.Grade == "Manager").Select(x => new LMEmployee() { EmpId = x.EmpId, EmpFName = x.EmpFName, EmpLName = x.EmpLName }).OrderBy(x => x.EmpId).ToArray();
            var queryManager = context.LMEmployees.Where(e => e.Grade == "Manager").Select(e => e.EmpId).ToArray();
            IEnumerable<Manager> items = queryManager.Select(a => (Manager)Enum.Parse(typeof(Manager), a.ToString()));

            ViewBag.Manager = new SelectList(items);

            return View();
        }

        [Authorize(Roles = "Admin")]
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
                var result = context.SaveChanges();    //le resultat vas etre 1 si le requete executé avec le successé.

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
