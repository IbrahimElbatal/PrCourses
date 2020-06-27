namespace PragimCourses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateCourseData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "StartDate",
                c => c.DateTime());
            AddColumn("dbo.Courses", "EndDate",
                c => c.DateTime(defaultValueSql: "GetDate()"));
            AddColumn("dbo.Courses", "Language",
                c => c.String(defaultValue: "English"));
            Sql("update courses set StartDate = GetDate(),Language='English'");
        }

        public override void Down()
        {
            DropColumn("dbo.Courses", "Language");
            DropColumn("dbo.Courses", "EndDate");
            DropColumn("dbo.Courses", "StartDate");
        }
    }
}
