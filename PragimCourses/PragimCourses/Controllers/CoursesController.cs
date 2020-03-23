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

        public ActionResult FreeCourses(int? page)
        {
            var freeCoursesId = _context.Categories
                .SingleOrDefault(c => c.Name.ToLower() == "free courses")?.Id;

            var courses = _context.CourseCategories.Include(c => c.Course).Where(c => c.CategoryId == freeCoursesId).ToList();
            return View(courses.ToPagedList(page ?? 1, 9));
        }

        public ActionResult ClassRoomCourses(int? page)
        {
            var classCoursesId = _context.Categories
                .SingleOrDefault(c => c.Name.ToLower() == "Classroom courses")?.Id;

            var courses = _context.CourseCategories.Include(c => c.Course).Where(c => c.CategoryId == classCoursesId).ToList();
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

            return RedirectToAction("FreeCourses", "Courses");
        }

        [HttpGet]
        public ActionResult AddClassRoomCourseDescription()
        {
            var courses = _context.CourseCategories
                 .Where(cc => cc.CategoryId == 3)
                 .Select(cc => cc.Course).ToList();

            ViewBag.CourseId = new SelectList(courses, "Id", "Description");

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var result = _context.CourseDetailsHeaders
                .Where(cd => cd.CourseId == id)
                .Include(cd => cd.Course)
                .Include(cd => cd.CourseBodies)
                .ToList();

            ViewBag.RelatedCourses = _context.CourseCategories
                .Where(c => c.CategoryId == 3)
                .Include(c => c.Course)
                .Select(c => c.Course)
                .OrderBy(c => Guid.NewGuid())
                .Take(3)
                .ToList();

            return View(result);
        }

    }
}