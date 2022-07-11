using Microsoft.AspNet.SignalR;
using NewChatClient.ChatClient;

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

            int flag;

            if (name[0] % 5 == 0)
            {
                flag = 0;

            }
            else if (name[0] % 5 == 1)
            {
                flag = 1;
                
            }
            else if (name[0] % 5 == 2)
            {
                flag = 2;
                
            }
            else
            {
                flag = 3;
            }
               
            Clients.All.AddNewMessageToPage(name, message, flag);
            client.SendMessage(message, Id);
        }

        public void IsTyping(string name)
        {
            Clients.All.sayWhoIsTyping(name);
        }
    }
}