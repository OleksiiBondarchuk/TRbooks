using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TRbooks.Startup))]
namespace TRbooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
