using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PragimCourses.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Support()
        {
            return View();
        }
        public ActionResult Subscribe()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult Testimonial()
        {
            return View();
        }
        public ActionResult FreeCourses()
        {
            return View();
        }
        public ActionResult ClassRoomCourses()
        {
            return View();
        }
        public ActionResult DownloadCourses()
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
    }
}