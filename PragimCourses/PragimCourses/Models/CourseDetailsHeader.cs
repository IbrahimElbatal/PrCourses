namespace PragimCourses.Models
{
    public class CourseDetailsHeader
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}