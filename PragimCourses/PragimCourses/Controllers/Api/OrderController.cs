using Microsoft.AspNet.Identity;
using PragimCourses.Models;
using PragimCourses.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PragimCourses.Controllers.Api
{
    public class OrderController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create([FromBody] string userName)
        {
            var cart = HttpContext.Current.Session["cart"] as List<CartViewModel>;
            if (cart == null)
                return BadRequest("Your Cart Is Empty");

            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                var user = _context.Users.SingleOrDefault(u => u.UserName == userName);
                if (user == null)
                    return NotFound();
                else
                    userId = user.Id;
            }
            foreach (var cartVM in cart)
            {
                var order = new Order()
                {
                    UserId = userId,
                    CourseId = cartVM.Course.Id,
                    Quantity = cartVM.Quantity
                };
                if (_context.Orders.FirstOrDefault(o => o.UserId == userId && o.CourseId == cartVM.Course.Id) != null)
                    return BadRequest("You Buy This Course before.");

                _context.Orders.Add(order);
            }
            _context.SaveChanges();

            HttpContext.Current.Session["cart"] = null;
            return Ok();
        }
    }
}
