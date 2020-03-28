using PragimCourses.Models;
using System.Web.Http;

namespace PragimCourses.Controllers.Api
{
    public class ReviewController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public ReviewController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Create(Review model)
        {
            _context.Reviews.Add(model);
            _context.SaveChanges();

            return Created(Request.RequestUri + "/" + model.Id, model);
        }
    }
}
