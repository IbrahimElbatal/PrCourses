using PragimCourses.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class EnrollmentConfiguration :
        EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentConfiguration()
        {
            Property(e => e.UserId)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Enrollment") { IsUnique = true, Order = 1 }));

            Property(e => e.CourseId)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Enrollment") { IsUnique = true, Order = 2 }));
        }
    }
}