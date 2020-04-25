using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SK2.Startup))]
namespace SK2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
