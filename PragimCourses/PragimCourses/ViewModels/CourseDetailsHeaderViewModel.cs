using PragimCourses.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PragimCourses.ViewModels
{
    public class CourseDetailsHeaderViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Header { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}