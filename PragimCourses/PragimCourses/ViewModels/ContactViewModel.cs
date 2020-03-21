using System.ComponentModel.DataAnnotations;

namespace PragimCourses.ViewModels
{
    public class ContactViewModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Your Name*")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        [Display(Name = "Your Email*")]
        public string Email { get; set; }

        [MaxLength(100)]
        [Display(Name = "Your Subject")]
        public string Subject { get; set; }

        [MaxLength(500)]
        [Display(Name = "Your Message")]

        public string Message { get; set; }

    }
}