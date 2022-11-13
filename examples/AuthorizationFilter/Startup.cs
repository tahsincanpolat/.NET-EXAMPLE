using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthorizationFilter.Startup))]
namespace AuthorizationFilter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
