using PragimCourses.Models;

namespace PragimCourses.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PragimCourses.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PragimCourses.Models.ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(c => c.Name,
                new Category() { Name = "Free Courses" },
                new Category() { Name = "Download Courses" },
                new Category() { Name = "ClassRoom Courses" });


            context.Courses.AddOrUpdate(c => new { c.Header, c.Description },
                new Course() { Header = "ASP.NET MVC", ImagePath = "~/Content/Images/FreeCourses/asp-mvc-360x270.jpg", Description = "ASP.NET Core MVC Tutorial for Beginners | .NET Core Tutorial", Price = 15 },
                new Course() { Header = "ASP.NET Razor Pages", ImagePath = "~/Content/Images/FreeCourses/asp.net-core-razor-pages-tutorial-3-360x270.png", Description = "ASP.NET Core Razor Pages Tutorial for Beginners", Price = 15 },
                new Course() { Header = "Angular Crud", ImagePath = "~/Content/Images/FreeCourses/angularjsCURD-360x270.jpg", Description = "Angular CRUD Tutorial", Price = 15 },
                new Course() { Header = "Bootstrap", ImagePath = "~/Content/Images/FreeCourses/bootstrap.jpg", Description = "Bootstrap Tutorial for Beginners", Price = 15 },
                new Course() { Header = "Javascript", ImagePath = "~/Content/Images/FreeCourses/java-script.jpg", Description = "JavaScript Tutorial for Beginners", Price = 15 },
                new Course() { Header = "JQuery", ImagePath = "~/Content/Images/FreeCourses/jquery.jpg", Description = "jQuery Tutorial for Beginners", Price = 15 },
                new Course() { Header = "Angular JS", ImagePath = "~/Content/Images/FreeCourses/angularjs.jpg", Description = "AngularJS Tutorial for Beginners", Price = 15 },
                new Course() { Header = "Angular 2", ImagePath = "~/Content/Images/FreeCourses/angular2-360x270.jpg", Description = "Angular 2 tutorial for beginners", Price = 15 },
                new Course() { Header = "Angular CLI", ImagePath = "~/Content/Images/FreeCourses/angularjsCLI-360x270.jpg", Description = "Angular CLI tutorial for beginners", Price = 15 },
                new Course() { Header = "Angular 6", ImagePath = "~/Content/Images/FreeCourses/angularjs6-360x270.jpg", Description = "Angular 6 tutorial for beginners", Price = 15 },
                new Course() { Header = "Web Services", ImagePath = "~/Content/Images/FreeCourses/webs-services.jpg", Description = "ASP.NET Web Services Tutorial", Price = 15 },
                new Course() { Header = "Web API", ImagePath = "~/Content/Images/FreeCourses/ASP.NET-Web-api.jpg", Description = "ASP.NET Web API Tutorial for Beginners", Price = 15 },
                new Course() { Header = "ASP.NET GridView", ImagePath = "~/Content/Images/FreeCourses/ASP.NET-GridView.jpg", Description = "ASP.NET GridView Tutorial for Beginners", Price = 15 },
                new Course() { Header = "Design patterns", ImagePath = "~/Content/Images/FreeCourses/design-patterns.jpg", Description = "Design patterns tutorial for Beginners", Price = 15 },
                new Course() { Header = "SQL Server", ImagePath = "~/Content/Images/FreeCourses/sql-1.jpg", Description = "SQL Server Tutorial for Beginners | SQL Tutorial for Beginners", Price = 15 },
                new Course() { Header = "SQL Q&A", ImagePath = "~/Content/Images/FreeCourses/sqlqa-360x270.jpg", Description = "SQL Server Interview Q&A", Price = 15 },
                new Course() { Header = "C# Interview", ImagePath = "~/Content/Images/FreeCourses/C-interview-questions-and-answers.jpg", Description = "C# interview questions and answers", Price = 15 },
                new Course() { Header = "Entity Framework", ImagePath = "~/Content/Images/FreeCourses/Entity-framework.jpg", Description = "Entity Framework Tutorial", Price = 15 },
                new Course() { Header = "Linq", ImagePath = "~/Content/Images/FreeCourses/linq-1-360x270.jpg", Description = "LINQ Tutorial", Price = 15 },
                new Course() { Header = "C Sharp", ImagePath = "~/Content/Images/FreeCourses/c.jpg", Description = "C Sharp tutorial for beginners", Price = 15 },
                new Course() { Header = "ADO.NET", ImagePath = "~/Content/Images/FreeCourses/ado-net-360x270.jpg", Description = "ADO.NET tutorial for beginners", Price = 15 },
                new Course() { Header = "ASP.NET", ImagePath = "~/Content/Images/FreeCourses/asp.net_.jpg", Description = "ASP.NET Tutorial for Beginners", Price = 15 },


                new Course() { Header = "All Courses", ImagePath = "~/Content/Images/DownloadCourses/downloads-1-360x270.jpg", Description = "Download all Videos & Slides", Price = 170 },
                new Course() { Header = "Videos & Slides", ImagePath = "~/Content/Images/DownloadCourses/slides-360x270.jpg", Description = "Buy DVD with all videos & slides", Price = 200 },
                new Course() { Header = "Slides", ImagePath = "~/Content/Images/DownloadCourses/downloads-1-360x270.jpg", Description = "Download all slides", Price = 50 },
                new Course() { Header = "ASP.NET Core", ImagePath = "~/Content/Images/DownloadCourses/aspnet-360x270.png", Description = "ASP.NET Core Tutorial for Beginners", Price = 50 },
                new Course() { Header = "Unit Testing", ImagePath = "~/Content/Images/DownloadCourses/slides-360x270.jpg", Description = "Unit Testing Videos, Slides & Code Files", Price = 10 },
                new Course() { Header = "Angular JS", ImagePath = "~/Content/Images/DownloadCourses/angularjs-360x270.jpg", Description = "Angular 1 (53 Videos & Slides - 7 Hours 10 Minutes)", Price = 50 },
                new Course() { Header = "Angular 2", ImagePath = "~/Content/Images/DownloadCourses/angularjs2-360x270.jpg", Description = "Angular 2 (43 Videos & Slides - 7 Hours 27 Minutes)", Price = 50 },
                new Course() { Header = "Angular CLI", ImagePath = "~/Content/Images/DownloadCourses/angular-cli-360x270.jpg", Description = "Angular CLI (26 Videos & Slides - 3 Hours 30 Minutes)", Price = 25 },
                new Course() { Header = "Angular CRUD", ImagePath = "~/Content/Images/DownloadCourses/angularjs2-360x270.jpg", Description = "Angular CRUD (71 Videos & Slides - 11 Hours 36 Minutes)", Price = 50 },
                new Course() { Header = "Angular 6", ImagePath = "~/Content/Images/DownloadCourses/download-360x270.jpeg", Description = "Angular 6 (38 Videos & Slides - 5 Hours 44 Minutes)", Price = 50 },
                new Course() { Header = "SOILD Design", ImagePath = "~/Content/Images/DownloadCourses/DesignPatternsCSharp-360x270.png", Description = "SOLID Design Principles (6 Videos & Slides - 51 Minutes)", Price = 25 },
                new Course() { Header = "Design Pattern", ImagePath = "~/Content/Images/DownloadCourses/solid-principles-object-oriented-design-360x270.png", Description = "Design Patterns(20 Videos & Slides - 4 Hours)", Price = 50 },
                new Course() { Header = "ASP.NET Web API", ImagePath = "~/Content/Images/DownloadCourses/ASP.NET-Web-api-360x270.jpg", Description = "ASP.NET Web API Videos & Slides (39 Videos & Slides - 6 Hours 55 Minutes)", Price = 50 },
                new Course() { Header = "Bootstrap", ImagePath = "~/Content/Images/DownloadCourses/bootstrap-360x270.jpg", Description = "Bootstrap (52 Videos & Slides - 6 Hours 27 Minutes)", Price = 50 },
                new Course() { Header = "JQuery", ImagePath = "~/Content/Images/DownloadCourses/jquery-1-360x270.jpg", Description = "jQuery (113 Videos & Slides - 22 Hours 41 Minutes)", Price = 50 },
                new Course() { Header = "Dot Net Basic", ImagePath = "~/Content/Images/DownloadCourses/csharp-net-360x270.png", Description = "Dot Net Basics & C#", Price = 50 },
                new Course() { Header = "SQL Server", ImagePath = "~/Content/Images/DownloadCourses/MSSQLServer-360x270.png", Description = "SQL Server & SQL Server Interview Questions & Answers", Price = 50 },
                new Course() { Header = "ASP.NET", ImagePath = "~/Content/Images/DownloadCourses/aspnet-360x270.png", Description = "ASP.NET (172 Videos & Slides - 39 Hours 16 Minutes)", Price = 50 },
                new Course() { Header = "ASP.NET MVC", ImagePath = "~/Content/Images/DownloadCourses/asp-mvc-360x270.jpg", Description = "ASP.NET MVC (100 Videos & Slides - 18 Hours 6 Minutes)", Price = 50 },
                new Course() { Header = "ADO.NET", ImagePath = "~/Content/Images/DownloadCourses/ado-360x270.jpg", Description = "ADO.NET (21 Videos & Slides - 5 Hours 57 Minutes)", Price = 50 },
                new Course() { Header = "ASP.NET GridView", ImagePath = "~/Content/Images/DownloadCourses/ASP.NET-GridView-360x270.jpg", Description = "ASP.NET GridView (61 Videos & Slides - 13 Hours 27 Minutes)", Price = 50 },
                new Course() { Header = "Web Services", ImagePath = "~/Content/Images/DownloadCourses/webs-services-360x270.jpg", Description = "ASP.NET Web Services (7 Videos & Slides - 1 Hour 34 Minutes)", Price = 20 },
                new Course() { Header = "WCF", ImagePath = "~/Content/Images/DownloadCourses/wcfimage-360x270.png", Description = "WCF (53 Videos & Slides - 12 Hours 1 Minute)", Price = 50 },
                new Course() { Header = "Entity Framework", ImagePath = "~/Content/Images/DownloadCourses/Entity-Framework-360x270.jpg", Description = "Entity Framework (25 Videos & Slides - 4 Hours 59 Minutes)", Price = 50 },
                new Course() { Header = "Linq", ImagePath = "~/Content/Images/DownloadCourses/LinqToSql-360x270.jpg", Description = "LINQ, LINQ to XML and LINQ to SQL", Price = 50 },
                new Course() { Header = "Javascript", ImagePath = "~/Content/Images/DownloadCourses/java-script-360x270.jpg", Description = "JavaScript & JavaScript with ASP.NET", Price = 50 },



                new Course() { Header = "DevOps", Description = "Best AWS training in Bangalore | DevOps with AWS training", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/devops-aws.jpg" },
                new Course() { Header = "MVC With Angular", Description = "ASP.NET Core MVC with Angular", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/mvc.jpg" },
                new Course() { Header = "UI With Angular", Description = "UI Developer with Angular", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/ui-dev.jpg" },
                new Course() { Header = "Angular 8", Description = "Angular 8", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/angularjs8-360x270.jpg" },
                new Course() { Header = "Tableau", Description = "Tableau", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/tableau.jpg" },
                new Course() { Header = "SalesForce", Description = "SalesForce", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/Salesforce.jpg" },
                new Course() { Header = "JAVA J2EE", Description = "JAVA J2EE", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/java-j2ee.png" },
                new Course() { Header = "Informatica", Description = "Informatica", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/informatica.jpg" },
                new Course() { Header = "MSBI", Description = "MSBI", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/msbi.jpg" },
                new Course() { Header = "Power BI", Description = "Power BI", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/power-bi.jpg" },
                new Course() { Header = "ORACLE DBA", Description = "ORACLE DBA", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/dba-360x270.jpg" },
                new Course() { Header = "HADOOP", Description = "HADOOP", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/hadoop-360x270.jpg" },
                new Course() { Header = "IBM MQ Admin", Description = "IBM MQ Admin", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/ibm-mq-360x270.jpg" },
                new Course() { Header = "ORACLE PL/SQL", Description = "ORACLE PL/SQL", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/plsql-360x270.jpg" },
                new Course() { Header = "Blueprism Product Suite-5.x", Description = "Blueprism Product Suite-5.x", Price = 0.00m, ImagePath = "~/Content/Images/ClassRoomCourses/blueprism-360x270.jpg" }
            );
        }
    }
}
