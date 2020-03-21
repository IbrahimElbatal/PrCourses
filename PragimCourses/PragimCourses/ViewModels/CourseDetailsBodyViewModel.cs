using PragimCourses.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PragimCourses.ViewModels
{
    public class CourseDetailsBodyViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Body { get; set; }

        [ForeignKey("CourseDetailsHeaderId")]
        public CourseDetailsHeader CourseDetailsHeader { get; set; }
        public int CourseDetailsHeaderId { get; set; }
    }
}