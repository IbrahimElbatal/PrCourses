using PragimCourses.Models;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class FeedbackConfiguration : EntityTypeConfiguration<Feedback>
    {
        public FeedbackConfiguration()
        {
            Property(f => f.Technology)
                .HasMaxLength(50)
                .IsRequired();

            Property(f => f.Punctuality)
                .HasMaxLength(50)
                .IsRequired();

            Property(f => f.TechnologyStrength)
                .HasMaxLength(50)
                .IsRequired();

            Property(f => f.TrainerName)
                .HasMaxLength(50)
                .IsOptional();

            Property(f => f.TrainerEmail)
                .HasMaxLength(50)
                .IsOptional();

            Property(f => f.Comment)
                .HasMaxLength(700)
                .IsRequired();
        }
    }
}