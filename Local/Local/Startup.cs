using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Local.Startup))]
namespace Local
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
