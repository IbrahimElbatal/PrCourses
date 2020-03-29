using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using PragimCourses.Models;

namespace PragimCourses.Configuration
{
    public class SubscriberConfiguration : EntityTypeConfiguration<Subscriber>
    {
        public SubscriberConfiguration()
        {
            Property(s => s.Email)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Subscriber_Email") { IsUnique = true }));
        }
    }
}