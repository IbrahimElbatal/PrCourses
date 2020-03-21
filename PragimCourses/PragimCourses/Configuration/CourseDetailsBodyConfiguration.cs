using PragimCourses.Models;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class CourseDetailsBodyConfiguration
        : EntityTypeConfiguration<CourseDetailsBody>
    {
        public CourseDetailsBodyConfiguration()
        {
            Property(c => c.Body)
                .HasMaxLength(200)
                .IsRequired();

            HasRequired(c => c.CourseDetailsHeader)
                .WithMany();
        }
    }
}