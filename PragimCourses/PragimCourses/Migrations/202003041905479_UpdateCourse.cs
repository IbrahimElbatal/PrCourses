namespace PragimCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ImagePath", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ImagePath");
        }
    }
}
