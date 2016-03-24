using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projecto2.Startup))]
namespace projecto2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
