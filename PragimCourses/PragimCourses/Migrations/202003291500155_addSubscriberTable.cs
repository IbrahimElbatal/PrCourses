namespace PragimCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubscriberTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "AK_Subscriber_Email");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Subscribers", "AK_Subscriber_Email");
            DropTable("dbo.Subscribers");
        }
    }
}
