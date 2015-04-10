using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MajdzikMvc.Startup))]
namespace MajdzikMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
