using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERestaurant.WebApp.Startup))]
namespace ERestaurant.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
