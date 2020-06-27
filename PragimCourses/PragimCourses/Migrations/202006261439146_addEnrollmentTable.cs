namespace PragimCourses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addEnrollmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    CourseId = c.Int(nullable: false),
                    EnrollmentDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => new { t.UserId, t.CourseId }, unique: true, name: "AK_Enrollment");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", "AK_Enrollment");
            DropTable("dbo.Enrollments");
        }
    }
}
