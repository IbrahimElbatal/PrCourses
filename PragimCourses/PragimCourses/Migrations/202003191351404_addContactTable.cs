namespace PragimCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContactTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(maxLength: 50),
                        Message = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "AK_Contact_Name")
                .Index(t => t.Email, unique: true, name: "AK_Contact_Email");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", "AK_Contact_Email");
            DropIndex("dbo.Contacts", "AK_Contact_Name");
            DropTable("dbo.Contacts");
        }
    }
}
