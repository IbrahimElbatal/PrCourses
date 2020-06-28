

using PragimCourses.Models;
using PragimCourses.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PragimCourses.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var courses = Session["cart"] as List<CartViewModel>;

            if (courses == null)
            {
                courses = new List<CartViewModel>();
            }

            return View(courses);
        }
        public ActionResult AddToCart(int id)
        {
            var cart = Session["cart"] as List<CartViewModel>;

            if (cart == null)
            {
                cart = new List<CartViewModel>();
            }

            var course = _context.Courses.Find(id);

            cart.Add(new CartViewModel() { Course = course, Quantity = 1 });

            Session["cart"] = cart;

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateQuantity(CartDto model)
        {
            var cart = Session["cart"] as List<CartViewModel>;

            var course = cart.Find(c => c.Course.Id == model.CourseId);
            course.Quantity = model.Quantity;

            Session["cart"] = cart;
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Checkout()
        {
            var courses = Session["cart"] as List<CartViewModel>;

            if (courses == null)
            {
                courses = new List<CartViewModel>();
            }

            return View(courses);
        }
    }

    public class CartDto
    {
        public int CourseId { get; set; }
        public int Quantity { get; set; }
    }
}