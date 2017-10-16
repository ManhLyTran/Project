using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tmp.Startup))]
namespace tmp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
