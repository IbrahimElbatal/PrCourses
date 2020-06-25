using PragimCourses.Models;
using System.Collections.Generic;

namespace PragimCourses.ViewModels
{
    public class CoursesFeedbackViewModel
    {
        public IEnumerable<Feedback> Feedback { set; get; }
        public IEnumerable<Course> FreeCourses { get; set; }
        public IEnumerable<Course> DownloadCourses { get; set; }
        public IEnumerable<Course> ClassroomCourses { get; set; }
    }
}