using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVDWebApi.Startup))]
namespace DVDWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
