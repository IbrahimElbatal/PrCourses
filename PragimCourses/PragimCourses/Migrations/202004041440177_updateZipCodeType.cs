namespace PragimCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateZipCodeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BillingInfos", "ZipCode", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.ShippingInfos", "ZipCode", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShippingInfos", "ZipCode", c => c.Byte(nullable: false));
            AlterColumn("dbo.BillingInfos", "ZipCode", c => c.Byte(nullable: false));
        }
    }
}
