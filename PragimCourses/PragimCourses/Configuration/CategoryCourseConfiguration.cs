using PragimCourses.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class CategoryCourseConfiguration : EntityTypeConfiguration<CourseCategory>
    {
        public CategoryCourseConfiguration()
        {
            HasKey(cc => new { cc.CategoryId, cc.CourseId });

            Property(cc => cc.CategoryId)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("CK_CategoryCourse", 1) { IsUnique = true }));

            Property(cc => cc.CourseId)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("CK_CategoryCourse", 2) { IsUnique = true }));
        }
    }
}