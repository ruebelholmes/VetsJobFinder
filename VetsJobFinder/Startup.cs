using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VetsJobFinder.Startup))]
namespace VetsJobFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
