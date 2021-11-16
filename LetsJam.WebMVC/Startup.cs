using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LetsJam.WebMVC.Startup))]
namespace LetsJam.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
