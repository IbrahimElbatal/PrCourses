using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PragimCourses.Models;
using PragimCourses.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;

namespace PragimCourses.Controllers.Api
{
    public class CourseController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CourseController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Create(CourseDescriptionViewModel model)
        {
            var courseHeader = new CourseDetailsHeader()
            {
                CourseId = model.CourseId,
                Header = model.Header
            };
            _context.CourseDetailsHeaders.Add(courseHeader);

            foreach (var body in model.Bodies)
            {
                var courseBody = new CourseDetailsBody()
                {
                    Body = body,
                    CourseDetailsHeaderId = courseHeader.Id
                };
                _context.CourseDetailsBodies.Add(courseBody);
            }

            _context.SaveChanges();

            if (model.CourseType == CourseType.FreeCourses)
            {
                var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

                foreach (var subscriber in _context.Subscribers)
                {
                    manager.EmailService.SendAsync(new IdentityMessage()
                    {
                        Destination = subscriber.Email,
                        Subject = "New Video Added",
                        Body = "New Video is added <br/> " +
                               "<a href='" + model.Bodies.ToArray()[2] + "'>Video Name :" + model.Header + "</a> <br/>" +
                               "<a href='" + model.Bodies.ToArray()[0] + "'>Text</a><br/>" +
                               "<a href='" + model.Bodies.ToArray()[1] + "'>Slides</a>"
                    });
                }

            }
            return Created(Url.Request.RequestUri.ToString() + '/' + courseHeader.Id, model);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _context.CourseDetailsHeaders
                .Include(ch => ch.CourseBodies)
                .Select(x => new { x.Header, x.CourseBodies }).ToList();
            return Ok(result);
        }
    }
}
