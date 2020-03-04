using System.Data.Entity;
using PragimCourses.Models;
using System.Linq;
using System.Web.Mvc;

namespace PragimCourses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
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
            var freeCoursesId = _context.Categories
                .SingleOrDefault(c => c.Name.ToLower() == "free courses").Id;

            var courses = _context.CourseCategories.Include(c => c.Course).Where(c => c.CategoryId == freeCoursesId).ToList();
            return View(courses);
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