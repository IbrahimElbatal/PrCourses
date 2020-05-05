using PragimCourses.Models;
using System.Data.Entity.ModelConfiguration;

namespace PragimCourses.Configuration
{
    public class ShippingInfoConfiguration : EntityTypeConfiguration<ShippingInfo>
    {
        public ShippingInfoConfiguration()
        {
            ToTable("ShippingInfos");

            Property(b => b.Company)
                .HasMaxLength(100)
                .IsRequired();

            Property(b => b.Address1)
                .HasMaxLength(150)
                .IsRequired();

            Property(b => b.Address2)
                .HasMaxLength(150)
                .IsOptional();

            Property(b => b.ZipCode)
                .HasMaxLength(5)
                .IsRequired();
            Property(b => b.City)
                .HasMaxLength(100)
                .IsRequired();


            Property(b => b.Country)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}