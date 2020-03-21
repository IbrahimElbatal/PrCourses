using PragimCourses.Models;
using PragimCourses.ViewModels;
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
            return View(_context.Feedbacks.ToList());
        }
        public ActionResult Support()
        {
            return View();
        }
        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Feedback()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Feedback(FeedbackViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var feedback = new Feedback()
            {
                Technology = model.Technology,
                Punctuality = model.Punctuality,
                TechnologyStrength = model.TechnologyStrength,
                Comment = model.Comment,
                TrainerEmail = model.TrainerEmail,
                TrainerName = model.TrainerName
            };

            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Testimonial()
        {
            return View(_context.Feedbacks.ToList());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!RecaptchaResponse.GetRecaptchaResponse().Success)
            {
                ModelState.AddModelError("", "Recaptcha failed");
                return View(model);
            }

            var contact = new Contact()
            {
                Name = model.Name,
                Email = model.Email,
                Subject = model.Subject,
                Message = model.Message
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}