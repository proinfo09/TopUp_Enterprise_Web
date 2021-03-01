using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Enterprise.Startup))]
namespace Web_Enterprise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
