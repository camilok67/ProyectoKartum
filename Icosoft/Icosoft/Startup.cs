using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Icosoft.Startup))]
namespace Icosoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
