using PragimCourses.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Contact_Name") { IsUnique = true }));

            Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Contact_Email") { IsUnique = true }));

            Property(c => c.Subject)
                .HasMaxLength(50)
                .IsOptional();

            Property(c => c.Message)
                .HasMaxLength(500)
                .IsOptional();

        }
    }
}