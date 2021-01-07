using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WritersBlockMVC.Startup))]
namespace WritersBlockMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
