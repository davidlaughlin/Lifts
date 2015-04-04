using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lifts.WebClient.Startup))]
namespace Lifts.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
