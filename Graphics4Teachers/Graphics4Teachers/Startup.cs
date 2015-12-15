using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Graphics4Teachers.Startup))]
namespace Graphics4Teachers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
