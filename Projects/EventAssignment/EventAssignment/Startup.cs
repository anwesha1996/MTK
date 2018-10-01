using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventAssignment.Startup))]
namespace EventAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
