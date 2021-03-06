using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatBox.Startup))]
namespace ChatBox
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
