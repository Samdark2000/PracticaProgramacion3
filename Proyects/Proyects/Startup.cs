using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyects.Startup))]
namespace Proyects
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
