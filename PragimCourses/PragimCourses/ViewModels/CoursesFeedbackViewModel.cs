using PragimCourses.Models;
using System.Collections.Generic;

namespace PragimCourses.ViewModels
{
    public class CoursesFeedbackViewModel
    {
        public IEnumerable<Feedback> Feedback { set; get; }
        public IEnumerable<CourseRatingViewModel> FreeCourses { get; set; }
        public IEnumerable<CourseRatingViewModel> DownloadCourses { get; set; }
        public IEnumerable<CourseRatingViewModel> ClassroomCourses { get; set; }
    }
}