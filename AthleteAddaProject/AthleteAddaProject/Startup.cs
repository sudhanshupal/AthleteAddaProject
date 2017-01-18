using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AthleteAddaProject.Startup))]
namespace AthleteAddaProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
