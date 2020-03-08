using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LicentaPrototip.Startup))]
namespace LicentaPrototip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
