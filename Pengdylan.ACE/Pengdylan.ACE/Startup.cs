using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pengdylan.ACE.Startup))]
namespace Pengdylan.ACE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
