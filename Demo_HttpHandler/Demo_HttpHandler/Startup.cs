using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo_HttpHandler.Startup))]
namespace Demo_HttpHandler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
