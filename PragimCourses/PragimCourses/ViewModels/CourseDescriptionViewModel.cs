using System.Collections.Generic;

namespace PragimCourses.ViewModels
{
    public class CourseDescriptionViewModel
    {
        public int CourseId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Bodies { get; set; }
    }
}