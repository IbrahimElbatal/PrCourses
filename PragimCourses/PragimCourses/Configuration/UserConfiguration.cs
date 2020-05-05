using PragimCourses.Models;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            Property(u => u.FirstName)
                .HasMaxLength(80)
                .IsRequired();

            Property(u => u.LastName)
                .HasMaxLength(80)
                .IsRequired();

        }
    }
}