using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Enterprise_Web.Startup))]
namespace Enterprise_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
