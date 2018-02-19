using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThomasHinesGuitar.Startup))]
namespace ThomasHinesGuitar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
