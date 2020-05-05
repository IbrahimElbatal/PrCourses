namespace PragimCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingBillingInfoShippingInfoTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.Byte(nullable: false),
                        Address1 = c.String(nullable: false, maxLength: 150),
                        Address2 = c.String(maxLength: 150),
                        City = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ShippingInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.Byte(nullable: false),
                        Address1 = c.String(nullable: false, maxLength: 150),
                        Address2 = c.String(maxLength: 150),
                        City = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.AspNetUsers", "ShippingInfoId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "BillingInfoId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShippingInfos", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BillingInfos", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ShippingInfos", new[] { "UserId" });
            DropIndex("dbo.BillingInfos", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "BillingInfoId");
            DropColumn("dbo.AspNetUsers", "ShippingInfoId");
            DropTable("dbo.ShippingInfos");
            DropTable("dbo.BillingInfos");
        }
    }
}
