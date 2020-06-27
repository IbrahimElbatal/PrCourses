using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PragimCourses.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Header { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Language { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}