using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final_Fin_De_Session.Startup))]
namespace Final_Fin_De_Session
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
