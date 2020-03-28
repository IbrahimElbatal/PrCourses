using System;

namespace PragimCourses.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public byte Rating { get; set; }
        public string Content { get; set; }
        public DateTime AddReviewDate { get; private set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Review()
        {
            AddReviewDate = DateTime.Now;
        }
    }
}