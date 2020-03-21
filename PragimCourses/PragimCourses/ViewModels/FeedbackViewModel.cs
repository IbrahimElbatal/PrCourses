using System.ComponentModel.DataAnnotations;

namespace PragimCourses.ViewModels
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Technology { get; set; }

        [MaxLength(50)]
        public string TrainerName { get; set; }

        [MaxLength(50)]
        public string TrainerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string Punctuality { get; set; }

        [Required]
        [MaxLength(50)]
        public string TechnologyStrength { get; set; }

        [Required]
        [MaxLength(700)]
        public string Comment { get; set; }
    }
}