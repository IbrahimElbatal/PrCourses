using Microsoft.AspNet.Identity.EntityFramework;
using PragimCourses.Configuration;
using System.Data.Entity;

namespace PragimCourses.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CourseDetailsHeader> CourseDetailsHeaders { get; set; }
        public DbSet<CourseDetailsBody> CourseDetailsBodies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<BillingInfo> BillingInfos { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CategoryCourseConfiguration());
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new FeedbackConfiguration());
            modelBuilder.Configurations.Add(new CourseDetailsHeaderConfiguration());
            modelBuilder.Configurations.Add(new CourseDetailsBodyConfiguration());
            modelBuilder.Configurations.Add(new ReviewConfiguration());
            modelBuilder.Configurations.Add(new SubscriberConfiguration());
            modelBuilder.Configurations.Add(new BillingInfoConfiguration());
            modelBuilder.Configurations.Add(new ShippingInfoConfiguration());
            modelBuilder.Configurations.Add(new EnrollmentConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());

            modelBuilder.Entity<ApplicationUser>()
                .HasRequired(u => u.BillingInfo)
                .WithRequiredPrincipal(b => b.User)
            .Map(map => map.MapKey("UserId"));


            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(u => u.ShippingInfo)
                .WithRequired(s => s.User)
                .Map(map => map.MapKey("UserId"));


            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}