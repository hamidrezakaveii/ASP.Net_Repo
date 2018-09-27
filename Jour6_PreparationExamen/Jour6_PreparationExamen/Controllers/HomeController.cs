using Jour6_PreparationExamen.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jour6_PreparationExamen.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var listActivity = Utils.GetInstance().GetListeActivity();
            return View(listActivity);
        }


        public ActionResult Vote()
        {
            ViewBag.list = Utils.GetInstance().GetListeActivity().Select(m => m.Nom);

            return View();
        }


        [HttpPost]
        public ActionResult Vote(FormCollection collection)
        {
            try
            {
                string nom = collection["Nom"];
                string activity = collection["listActivities"];

                Utils.GetInstance().InsertVote(nom, activity);

                return RedirectToAction("Result");
            }
            catch
            {
                return View();
            }

        
        }


        public ActionResult Result()
        {
            Dictionary<string, string> listVotes = new Dictionary<string, string>();

            listVotes = Utils.GetInstance().GetVotes();

            return View(listVotes);
        }



    }
}
