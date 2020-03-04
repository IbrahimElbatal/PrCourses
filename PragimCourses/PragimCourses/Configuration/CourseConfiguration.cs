using PragimCourses.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(c => c.Header)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("Ak_Course_Name") { IsUnique = true }));

            Property(c => c.Description)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.ImagePath)
                .HasMaxLength(200)
                .IsRequired();

            Property(c => c.Price)
                .HasPrecision(18, 2);


        }
    }
}