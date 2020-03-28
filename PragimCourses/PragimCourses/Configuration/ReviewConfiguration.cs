using PragimCourses.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Review", 2) { IsUnique = true }));

            Property(r => r.CourseId)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Review", 1) { IsUnique = true }));

            Property(r => r.Email)
                .HasMaxLength(50)
                .IsOptional();

            Property(r => r.Rating)
                .IsRequired();

            Property(r => r.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(r => r.Content)
                .HasMaxLength(200)
                .IsRequired();

            HasRequired(r => r.Course)
                .WithMany(c => c.Reviews);
        }
    }
}