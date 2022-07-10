using Microsoft.AspNet.SignalR;
using NewChatClient.ChatClient;
using Microsoft.AspNet.SignalR.Hubs;
using System.Linq;
using System.Collections.Generic;

namespace SignalRChat
{
    public class ChatHub : Hub, IService1Callback
    {
        bool isConnected = false;
        public Service1Client client;

        int Id;

        public void MessageCallback(string msg)
        {

        }

        public void Send(string name, string message)
        {
            if (!isConnected)
            {
                if (client == null)
                {
                    client = new Service1Client(new System.ServiceModel.InstanceContext(this));
                }

                Id = client.Connect(name);

                isConnected = true;
            }

            int flag = client.PassColor();
            Clients.All.AddNewMessageToPage(name, message, flag);
            client.SendMessage(message, Id);
        }

        public void IsTyping(string name)
        {
            Clients.All.sayWhoIsTyping(name);
        }

        public List<User> GetUsers()
        {
            var users = client.Users();

            return users.ToList<User>();
        }

        public List<Message> GetMessages()
        {
            var messages = client.Messages();

            return messages.ToList<Message>();
        }
    }
}