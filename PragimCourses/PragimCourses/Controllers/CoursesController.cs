using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using PragimCourses.Models;
using PragimCourses.ViewModels;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PragimCourses.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Courses(int? page)
        {
            var courses = _context.CourseCategories
                .Where(cc => cc.CategoryId == 1 || cc.CategoryId == 3)
                .OrderBy(c => c.CategoryId)
                .Select(cc => cc.Course)
                .Select(c => new CourseRatingViewModel()
                {

                    Id = c.Id,
                    Description = c.Description,
                    EndDate = c.EndDate,
                    Header = c.Header,
                    ImagePath = c.ImagePath,
                    Language = c.Language,
                    Price = c.Price,
                    StartDate = c.StartDate,
                    Enrollments = c.Enrollments,
                    Reviews = c.Reviews
                });

            return View(courses.ToPagedList(page ?? 1, 12));
        }
        public ActionResult FreeCourses(int? page)
        {
            var freeCoursesId = _context.Categories
                .SingleOrDefault(c => c.Name.ToLower() == "free courses")?.Id;

            var courses = _context.CourseCategories
                .Include(c => c.Course.Enrollments)
                .Where(c => c.CategoryId == freeCoursesId)
                .Select(c => new CourseRatingViewModel()
                {
                    Id = c.Course.Id,
                    Description = c.Course.Description,
                    EndDate = c.Course.EndDate,
                    Header = c.Course.Header,
                    ImagePath = c.Course.ImagePath,
                    Language = c.Course.Language,
                    Price = c.Course.Price,
                    StartDate = c.Course.StartDate,
                    Enrollments = c.Course.Enrollments,
                    Reviews = c.Course.Reviews
                }).OrderBy(c => c.Id);

            return View(courses.ToPagedList(page ?? 1, 9));
        }

        public ActionResult ClassRoomCourses(int? page)
        {
            var classCoursesId = _context.Categories
                .SingleOrDefault(c => c.Name.ToLower() == "Classroom courses")?.Id;

            var courses = _context.CourseCategories
                .Include(c => c.Course.Enrollments)
                .Where(c => c.CategoryId == classCoursesId)
                .Select(c => new CourseRatingViewModel()
                {
                    Id = c.Course.Id,
                    Description = c.Course.Description,
                    EndDate = c.Course.EndDate,
                    Header = c.Course.Header,
                    ImagePath = c.Course.ImagePath,
                    Language = c.Course.Language,
                    Price = c.Course.Price,
                    StartDate = c.Course.StartDate,
                    Enrollments = c.Course.Enrollments,
                    Reviews = c.Course.Reviews
                }).OrderBy(c => c.Id);

            return View(courses.ToPagedList(page ?? 1, 9));
        }
        public ActionResult DownloadCourses()
        {
            var downloadCoursesId = _context.Categories
                .SingleOrDefault(c => c.Name.ToLower() == "download courses")?.Id;

            var courses = _context.CourseCategories.Include(c => c.Course).Where(c => c.CategoryId == downloadCoursesId).ToList();
            return View(courses);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CourseViewModel()
            {
                Categories = new SelectList(_context.Categories.ToList(),
                    "Id",
                    "Name")
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel model, HttpPostedFileBase postedFile)
        {
            model.Categories = new SelectList(_context.Categories.ToList(),
                "Id",
                "Name");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = _context.Categories.Find(model.CategoryId)?.Name;
            category = category?.Replace(" ", "");

            if (category != null)
            {
                var fileName =
                    Path.Combine(Server.MapPath("~/Content/Images/" + category + "/"), postedFile.FileName);
                postedFile.SaveAs(fileName);

                model.ImagePath = "~/Content/Images/" + category + "/" + postedFile.FileName;
            }

            var course = new Course()
            {
                Header = model.Header,
                Description = model.Description,
                ImagePath = model.ImagePath,
                Price = model.Price
            };
            var courseCategory = new CourseCategory()
            {
                CategoryId = model.CategoryId,
                CourseId = course.Id
            };
            _context.Courses.Add(course);
            _context.CourseCategories.Add(courseCategory);

            _context.SaveChanges();

            if (model.CategoryId == (int)CourseType.FreeCourses)
            {
                var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

                foreach (var subscriber in _context.Subscribers)
                {
                    manager.EmailService.SendAsync(new IdentityMessage()
                    {
                        Destination = subscriber.Email,
                        Subject = "New Course Added",
                        Body = "New Course is added <br/> " +
                               "Course Header is : " + model.Header +
                               "Course Description is : " + model.Description
                    });
                }
            }
            return RedirectToAction("FreeCourses", "Courses");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
            {
                return HttpNotFound($"the course with {id} not found it might be delated.");
            }

            var category = _context.CourseCategories
                .Include(c => c.Category)
                .FirstOrDefault(cc => cc.CourseId == course.Id)?.Category;

            var model = new CourseViewModel()
            {
                Categories = new SelectList(_context.Categories.ToList(),
                    "Id",
                    "Name"),
                Id = course.Id,
                Header = course.Header,
                Description = course.Description,
                ImagePath = course.ImagePath,
                Price = course.Price,
                CategoryId = category.Id
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Header,Description,ImagePath,CategoryId")]CourseViewModel model, HttpPostedFileBase postedFile)
        {
            model.Categories = new SelectList(_context.Categories.ToList(),
                "Id",
                "Name");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var courseInDb = _context.Courses.Find(model.Id);
            if (courseInDb == null)
            {
                return HttpNotFound();
            }

            var category = _context.Categories.Find(model.CategoryId)?.Name;
            category = category?.Replace(" ", "");
            model.ImagePath = courseInDb.ImagePath;
            if (category != null && postedFile != null)
            {
                var fileName =
                    Path.Combine(Server.MapPath("~/Content/Images/" + category + "/"), postedFile.FileName);
                postedFile.SaveAs(fileName);

                model.ImagePath = "~/Content/Images/" + category + "/" + postedFile.FileName;
            }

            courseInDb.Header = model.Header;
            courseInDb.Description = model.Description;
            courseInDb.ImagePath = model.ImagePath;
            courseInDb.Price = model.Price;

            _context.SaveChanges();
            return RedirectToAction("FreeCourses", "Courses");
        }


        [HttpGet]
        public ActionResult AddCourseDescription()
        {
            ViewBag.CourseTypes = new SelectList(_context.Categories.ToList(),
                "Id",
                "Name");

            return View();
        }

        [HttpGet]
        public ActionResult GetCourses(int courseType)
        {
            var courses = _context.CourseCategories
                .Where(cc => cc.CategoryId == courseType)
                .Select(cc => cc.Course).ToList();

            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var result = _context.CourseDetailsHeaders
                .Where(cd => cd.CourseId == id)
                .Include(cd => cd.CourseBodies)
                .ToList();

            var course = _context.Courses
                .Where(c => c.Id == id)
                .Include(c => c.Enrollments)
                .Include(c => c.Reviews)
                .SingleOrDefault();

            if (course == null)
                return HttpNotFound("The Course You Want Not Found");

            int categoryId = _context.CourseCategories
                .Where(cc => cc.CourseId == id)
                .Select(c => c.Category).Single()
                .Id;
            var courseWithRating = new CourseRatingViewModel()
            {
                CategoryId = categoryId,
                Id = course.Id,
                Enrollments = course.Enrollments,
                Reviews = course.Reviews,
                Description = course.Description,
                EndDate = course.EndDate,
                Header = course.Header,
                ImagePath = course.ImagePath,
                Language = course.Language,
                Price = course.Price,
                StartDate = course.StartDate
            };
            ViewBag.Course = courseWithRating;

            var userId = User.Identity.GetUserId();
            ViewBag.Enrollment = _context.Enrollments
                .SingleOrDefault(e => e.UserId == userId && e.CourseId == course.Id);

            var courses = _context.CourseCategories
                .Where(c => c.Category.Id == categoryId)
                .Select(c => c.Course)
                .OrderBy(c => Guid.NewGuid())
                .Take(3)
                .AsNoTracking();

            ViewBag.RelatedCourses = courses
                .Select(c => new CourseRatingViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    EndDate = c.EndDate,
                    Header = c.Header,
                    ImagePath = c.ImagePath,
                    Language = c.Language,
                    Price = c.Price,
                    StartDate = c.StartDate,
                    Enrollments = c.Enrollments,
                    Reviews = c.Reviews
                });

            return View(result);
        }
    }
}