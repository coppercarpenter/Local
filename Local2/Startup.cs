using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Local2.Startup))]
namespace Local2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
