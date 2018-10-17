using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JangMVCWebSite.Startup))]
namespace JangMVCWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
