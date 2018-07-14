using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HitaRasDhara.Startup))]
namespace HitaRasDhara
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
