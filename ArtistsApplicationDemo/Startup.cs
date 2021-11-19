using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtistsApplicationDemo.Startup))]
namespace ArtistsApplicationDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
