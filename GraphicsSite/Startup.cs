using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraphicsSite.Startup))]
namespace GraphicsSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
