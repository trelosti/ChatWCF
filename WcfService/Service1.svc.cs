using ChatModel;
using CommonChatContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        List<User> users = new List<User>();
        int id = 1;

        public int Connect(string name)
        {
            User user = new User()
            {
                ID = id++,
                Name = name,
                operationContext = OperationContext.Current
            };

            SendMessage($"{user.Name} joined the chat", 0);
            users.Add(user);
            insertUser(user);

            return user.ID;

        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);

            if (user != null)
            {
                users.Remove(user);
                SendMessage($"{user.Name} left the chat", 0);
            }
        }

        public void SendMessage(string msg, int id)
        {
            string username = null;
            DateTime dateTime = DateTime.UtcNow;
            string dateStr = dateTime.ToString();
            foreach (var item in users)
            {
                StringBuilder message = new StringBuilder(dateStr).Append(" ");

                var user = users.FirstOrDefault(i => i.ID == id);

                if (user != null)
                {
                    message.Append($"  {user.Name}: ");
                    username = user.Name;
                }

                message.Append(msg);

                item.operationContext.GetCallbackChannel<IServiceChatCallback>().MessageCallback(message.ToString());
            }

            

            if (id != 0)
            {
                insertMessage(new Message
                {
                    UserId = id,
                    Msg = msg,
                    Username = username ?? "unknown",
                    Date = dateTime
                });
            }


        }

        public async void insertMessage(Message msg)
        {
            using (var chatContext = new ChatContext())
            {
                chatContext.Messages.Add(msg);
                await chatContext.SaveChangesAsync();
            }
        }

        public async void insertUser(User user)
        {
            using (var chatContext = new ChatContext())
            {
                chatContext.Users.Add(user);
                await chatContext.SaveChangesAsync();
            }
        }

        public string displayString(string str)
        {
            return str;
        }
    }
}
