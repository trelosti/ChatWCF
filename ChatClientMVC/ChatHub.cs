using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using ChatClientMVC.ChatClient;


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

            Clients.All.broadcastMessage(name, message);
            client.SendMessage(message, Id);
        }
    }
}