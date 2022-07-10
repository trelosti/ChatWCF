using NewChatClient.ChatClient;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public Service1Client client;

        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}

