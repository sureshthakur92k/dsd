using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dsd.Startup))]
namespace dsd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
