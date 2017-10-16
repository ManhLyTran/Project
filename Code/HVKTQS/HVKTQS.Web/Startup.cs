using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HVKTQS.Web.Startup))]
namespace HVKTQS.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
