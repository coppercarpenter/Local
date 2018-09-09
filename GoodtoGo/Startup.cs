using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoodtoGo.Startup))]
namespace GoodtoGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
