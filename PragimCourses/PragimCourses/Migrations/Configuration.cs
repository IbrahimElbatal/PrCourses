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


            context.Courses.AddOrUpdate(c => c.Header,
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
                new Course() { Header = "ASP.NET", ImagePath = "~/Content/Images/FreeCourses/asp.net_.jpg", Description = "ASP.NET Tutorial for Beginners", Price = 15 }
                );
        }
    }
}
