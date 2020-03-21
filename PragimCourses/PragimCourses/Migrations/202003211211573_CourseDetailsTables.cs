namespace PragimCourses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CourseDetailsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseDetailsBodies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Body = c.String(nullable: false, maxLength: 200),
                    CourseDetailsHeaderId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseDetailsHeaders", t => t.CourseDetailsHeaderId, cascadeDelete: true)
                .Index(t => t.CourseDetailsHeaderId);

            CreateTable(
                "dbo.CourseDetailsHeaders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Header = c.String(nullable: false, maxLength: 200),
                    CourseId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.CourseDetailsBodies", "CourseDetailsHeaderId", "dbo.CourseDetailsHeaders");
            DropForeignKey("dbo.CourseDetailsHeaders", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseDetailsHeaders", new[] { "CourseId" });
            DropIndex("dbo.CourseDetailsBodies", new[] { "CourseDetailsHeaderId" });
            DropTable("dbo.CourseDetailsHeaders");
            DropTable("dbo.CourseDetailsBodies");
        }
    }
}
