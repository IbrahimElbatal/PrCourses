using System;

namespace PragimCourses.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? AddedDate { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ApplicationUser User { get; set; }
    }
}