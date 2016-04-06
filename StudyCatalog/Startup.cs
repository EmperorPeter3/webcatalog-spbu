using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyCatalog.Startup))]
namespace StudyCatalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
