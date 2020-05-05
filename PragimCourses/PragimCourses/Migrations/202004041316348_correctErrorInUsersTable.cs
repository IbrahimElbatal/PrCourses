namespace PragimCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctErrorInUsersTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ShippingInfoId");
            DropColumn("dbo.AspNetUsers", "BillingInfoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BillingInfoId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ShippingInfoId", c => c.Int(nullable: false));
        }
    }
}
