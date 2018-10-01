using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(event_management1.Startup))]
namespace event_management1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
