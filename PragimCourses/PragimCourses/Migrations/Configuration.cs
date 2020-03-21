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
            context.Feedbacks.AddOrUpdate(c => c.TrainerName, new Feedback[]
            {
                new Feedback(){Technology = "Oracle Developer",TrainerEmail = null,Punctuality = "Always In Time",TechnologyStrength = "Good",TrainerName = "Samir",Comment = "Every institute says they provide placements and never do that after training, but Pragim Technologies is the only institute who helped me get a job immediately after my training. The quality of the training is really good in Pragim Technologies. Real time project along with the interview questions is also explained by our OBIEE trainer."},
                new Feedback(){Technology = "SharePoint Developer",TrainerEmail = null,Punctuality = "Always In Time",TechnologyStrength = "Good",TrainerName = "Noha",Comment = "Hello Pragim Technologies. I have been following your videos since last one year and just got a job in an MNC. They asked me all about SQL, GAC and DLL Hell. I have given almost 100% answer to all question just because of your video tutorials sir. I am coming from medium class family and you changed my life. I do not have enough words. God bless you sir. I promise I will do any thing for you. Hatts off to you sir. Thank you so much. You Changed my life until i live i can not forget you."},
                new Feedback(){Technology = "Database Administrator",TrainerEmail = null,Punctuality = "Always In Time",TechnologyStrength = "Good",TrainerName = "Mona",Comment = "Hello KudVenkat sir, I would like to express my gratitude to You. Your DVDs with all the slides and videos helped a lot. I got a job in 2 months. I really admire the way you professionally provide information. I do not have many words to describe my admiration for You. But can only say one thing: I searched the entire internet and youtube all and I can assure You channel is the best channel that only can be found (even paid resources on the Internet can not be compared with your product). I am very grateful to you for the work you have done. if you need any help, I will be very grateful. I have shared your youtube and blog links in internet forums and social networks like facebook"},
                new Feedback(){Technology = "Php Developer",TrainerEmail = null,Punctuality = "Always In Time",TechnologyStrength = "Good",TrainerName = "Asmaa",Comment = "Hi Pragim Technologies, your training is so awesome. Without even ever doing c or c++ or any other programming language, I am able to develop small projects using Visual studio and even MVC. Many people suggested that it is not possible being from biochemistry background to become a .NET developer but I am sure that nothing is impossible and I proved that with your training. Your training institute is awesome and your training is more than sufficient if anyone has good motivation to become a software engineer. Its that good."},
                new Feedback(){Technology = "DotNet Developer",TrainerEmail = null,Punctuality = "Always In Time",TechnologyStrength = "Good",TrainerName = "Ibrahim",Comment = "In PRAGIM Technologies, they did not ask me for any registration fee. They gave me a chance to attend the classes free for one week. After one week, if I feel the training is good I can continue, otherwise we can quit without paying anything. Dotnet trainer in PRAGIM Technologies has 8 years of experience. I also spoke to the previous batch students who were placed in different organizations. After speaking with old batch students, I became very confident obout their quality of training, trainer and placement programs."},
                new Feedback(){Technology = "DotNet Developer",TrainerEmail = null,Punctuality = "Always In Time",TechnologyStrength = "Good",TrainerName = "Ali",Comment = "I got my first job as junior software developer and really want to thank you as when I was preparing for interviews videos uploaded by you on .net technologies helped so much. I bought your DVDs from your website and are very useful. Thank you Venkat sir."},
            });
        }
    }
}
