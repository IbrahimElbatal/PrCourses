namespace PragimCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Technology = c.String(nullable: false, maxLength: 50),
                        TrainerName = c.String(maxLength: 50),
                        TrainerEmail = c.String(maxLength: 50),
                        Punctuality = c.String(nullable: false, maxLength: 50),
                        TechnologyStrength = c.String(nullable: false, maxLength: 50),
                        Comment = c.String(nullable: false, maxLength: 700),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
