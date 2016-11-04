using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloWebforms.Startup))]
namespace HelloWebforms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
