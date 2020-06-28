using PragimCourses.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PragimCourses.ViewModels
{
    public class CourseRatingViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Language { get; set; }
        public int? CategoryId { get; set; }

        public int Count
        {
            get { return this.Reviews.Count == 0 ? 1 : this.Reviews.Count; }
        }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

        public CourseRatingViewModel()
        {
            Reviews = new Collection<Review>();
            Enrollments = new Collection<Enrollment>();
        }

        public int Rating
        {
            get
            {
                var rate = Math.Floor((float)CalculateRating() / Count);
                return Convert.ToInt16(rate);
            }
        }
        private int CalculateRating(int rate = 5)
        {
            var reviews = this.Reviews.Where(r => r.CourseId == Id).ToList();

            if (rate <= 0)
            {
                return 0;
            }
            return rate * reviews.Count(x => x.Rating == rate) + CalculateRating(rate - 1);
        }
    }
}