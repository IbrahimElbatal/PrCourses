using PragimCourses.Models;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class CourseDetailsHeaderConfiguration
        : EntityTypeConfiguration<CourseDetailsHeader>
    {
        public CourseDetailsHeaderConfiguration()
        {
            Property(c => c.Header)
                .HasMaxLength(200)
                .IsRequired();

            HasRequired(c => c.Course)
                .WithMany();
        }
    }
}