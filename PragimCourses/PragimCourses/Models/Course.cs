using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PragimCourses.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Review> Reviews { get; private set; }

        public Course()
        {
            Reviews = new Collection<Review>();
        }
    }
}