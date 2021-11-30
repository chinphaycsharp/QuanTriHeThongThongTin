using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chatProject.Startup))]
namespace chatProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
