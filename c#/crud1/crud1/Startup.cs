using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(crud1.Startup))]
namespace crud1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
