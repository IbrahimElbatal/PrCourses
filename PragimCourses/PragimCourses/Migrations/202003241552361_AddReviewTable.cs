namespace PragimCourses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddReviewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Email = c.String(maxLength: 50),
                    Title = c.String(nullable: false, maxLength: 100),
                    Rating = c.Byte(nullable: false),
                    Content = c.String(nullable: false, maxLength: 200),
                    AddReviewDate = c.DateTime(nullable: false, defaultValueSql: "GetDate()"),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Reviews");
        }
    }
}
