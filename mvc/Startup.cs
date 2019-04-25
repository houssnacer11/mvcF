using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieCyrine.Startup))]
namespace MovieCyrine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
