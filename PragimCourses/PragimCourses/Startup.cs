using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PragimCourses.Startup))]
namespace PragimCourses
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
