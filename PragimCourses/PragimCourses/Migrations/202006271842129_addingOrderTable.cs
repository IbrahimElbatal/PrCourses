namespace PragimCourses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addingOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AddedDate = c.DateTime(defaultValueSql: "GETDATE()"),
                    Quantity = c.Int(nullable: false),
                    UserId = c.String(nullable: false, maxLength: 128),
                    CourseId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => new { t.UserId, t.CourseId }, unique: true, name: "AK_Order");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "CourseId", "dbo.Courses");
            DropIndex("dbo.Orders", "AK_Order");
            DropTable("dbo.Orders");
        }
    }
}
