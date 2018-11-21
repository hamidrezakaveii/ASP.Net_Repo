using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gestion_Des_Conges_2.Models;
using Newtonsoft.Json;

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



        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Login(Login login, string ReturnUrl)
        {


            string msg = "";

            if (Request.HttpMethod == "POST")
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
                    ViewData["action"] = "The request was transferred successfully.";
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

                
                try
                {
                    context.SaveChanges();

                    //ntext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }


                return RedirectToAction("RequestCheck");
            }







            return View(verifyItem);
        }




        [Authorize(Roles = "Admin")]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AllRequest()
        {

            var allRequest = context.LMLeaveHistories.Select(r => r);


            return View(allRequest);
        }



        [Authorize(Roles = "Admin")]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AllEmployee()
        {
            //ReportController rc = new ReportController();



            var listEmployee = ReportController.GetEmployees();



            return View(listEmployee);
        }


        //Hosted web API REST Service base url  
        string Baseurl = "http://127.0.0.1:12138/";
        public async Task<ActionResult> AllEmployees()
        {
            List<LMEmployee> EmpInfo = new List<LMEmployee>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/GetEmployees");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<LMEmployee>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(EmpInfo);
            }
        }



        //[Authorize(Roles = "Admin")]
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    ViewBag.Grade = new SelectList(Enum.GetValues(typeof(Grade)), Grade.Employee);
        //    ViewBag.Sex = new SelectList(Enum.GetValues(typeof(Sex)), Sex.Male);
        //    ViewBag.Grade = new SelectList(Enum.GetValues(typeof(Grade)), Grade.Employee);

        //    var queryManager = context.LMEmployees.Where(e => e.Grade == "Manager").Select(x => new LMEmployee() { EmpId = x.EmpId, EmpFName = x.EmpFName, EmpLName = x.EmpLName }).OrderBy(x => x.EmpId).ToArray();
        //    var queryManager = context.LMEmployees.Where(e => e.Grade == "Manager").Select(e => e.EmpId).ToArray();
        //    IEnumerable<Manager> items = queryManager.Select(a => (Manager)Enum.Parse(typeof(Manager), a.ToString()));

        //    ViewBag.Manager = new SelectList(items);
        //    ViewData["msg"] = "";

        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {

            if (Request.HttpMethod == "POST")
            {
                //int checkEmployee = 0;
                var empId = Convert.ToInt32(collection.Get("EmpId"));
                var checkEmployee = context.LMEmployees.Where(e => e.EmpId == empId).FirstOrDefault();

                if (checkEmployee != null)
                {
                    ViewData["msg"] = "The employee with the same id exist.";
                    return View();
                }

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
                int result =0;
                try
                {
                    result = context.SaveChanges(); //le resultat vas etre 1 si le requete executé avec le successé.

                    //ntext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
           
                    if (result == 1)
                    {
                        ViewData["msg"] = "The employee created successfully.";
                        return View();
                    }

            }

            return View();

        }


    }
}
