namespace PragimCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviewNavigationProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", new[] { "CourseId", "Name" }, unique: true, name: "AK_Review");
            AddForeignKey("dbo.Reviews", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "CourseId", "dbo.Courses");
            DropIndex("dbo.Reviews", "AK_Review");
            DropColumn("dbo.Reviews", "CourseId");
        }
    }
}
