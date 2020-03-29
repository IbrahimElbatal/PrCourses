using PragimCourses.Models;
using System.Linq;
using System.Web.Http;

namespace PragimCourses.Controllers.Api
{
    public class SubscriberController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public SubscriberController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Create(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();

            var url = Url.Request.RequestUri.Scheme;
            url += "://" + Url.Request.RequestUri.Host;
            return Created(url + "/" + subscriber.Id, subscriber);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_context.Subscribers.ToList());
        }
    }
}