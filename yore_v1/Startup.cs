using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(yore_v1.Startup))]
namespace yore_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
