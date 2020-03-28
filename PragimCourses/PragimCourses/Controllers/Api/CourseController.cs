using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using PragimCourses.Models;
using PragimCourses.ViewModels;

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
            return Created(Url.Request.RequestUri.ToString() + '/' + courseHeader.Id,model);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _context.CourseDetailsHeaders
                .Include(ch => ch.CourseBodies)
                .Select(x=>new{x.Header,x.CourseBodies}).ToList();
            return Ok(result);
        }
    }
}
