using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PragimCourses.Models;
using PragimCourses.ViewModels;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PragimCourses.Controllers.Api
{
    public class EnrollmentController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]int courseId)
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
                return NotFound();

            var enrollment = new Enrollment()
            {
                CourseId = courseId,
                UserId = userId,
                EnrollmentDate = DateTime.Now
            };
            _context.Enrollments.Add(enrollment);

            _context.SaveChanges();

            return Ok(enrollment.EnrollmentDate);
        }

        [Route("api/LoginWithEnrollment")]
        [HttpPost]
        public IHttpActionResult Create(LoginWithEnrollment data)
        {
            var signInManager = HttpContext
                    .Current
                    .GetOwinContext()
                    .Get<ApplicationSignInManager>();
            var userManager = HttpContext
                .Current
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            var user =
                userManager.FindByEmail(data.Email) == null ?
                    userManager.FindByName(data.Email) :
                    userManager.FindByEmail(data.Email);

            var result = signInManager
                    .PasswordSignIn(user.UserName, data.Password, false, false);

            if (result != SignInStatus.Success)
            {
                return BadRequest("can't log in");
            }

            if (user.Id == null)
                return NotFound();

            var enrollmentInDb = _context.Enrollments
                .SingleOrDefault(e => e.UserId == user.Id && e.CourseId == data.CourseId);
            if (enrollmentInDb != null)
                return Ok();

            var enrollment = new Enrollment()
            {
                UserId = user.Id,
                CourseId = data.CourseId,
                EnrollmentDate = DateTime.Now
            };
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return Ok();
        }
    }
}
