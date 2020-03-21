namespace PragimCourses.Models
{
    public class CourseDetailsBody
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public CourseDetailsHeader CourseDetailsHeader { get; set; }
        public int CourseDetailsHeaderId { get; set; }
    }
}