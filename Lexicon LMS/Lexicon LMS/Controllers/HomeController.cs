using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lexicon_LMS.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Default()
        {


            ViewBag.Title = "Default";
            return View("Index");

        }
        [Authorize(Roles = "Teacher")]

        public ActionResult Admin()
        {
            ViewBag.Title = "Teacher";
            return View("Index");
        }


        [Authorize(Roles = "Student")]

        public ActionResult Editor()
        {
            ViewBag.Title = "Student";
            return View("Index");
        }


    }
}