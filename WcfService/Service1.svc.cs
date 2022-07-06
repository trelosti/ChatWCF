using ChatModel;
using CommonChatContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        UnitOfWork unitOfWork;
        
        List<User> users = new List<User>();

        public int Connect(string name)
        {
            unitOfWork = new UnitOfWork();

            var foundUser = users.FirstOrDefault(i => i.Name == name);

            if (foundUser == null) 
            { 

                User user = new User()
                {
                    Name = name,
                    operationContext = OperationContext.Current
                };

                users.Add(user);
                unitOfWork.Users.insertItem(user);
                    
                try 
                {
                    unitOfWork.Save();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

                return user.ID;
            }
            else
            {
                return foundUser.ID;
            }
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

            }



            if (id != 0)
            {
                unitOfWork.Messages.insertItem(new Message
                {
                    UserId = id,
                    Msg = msg,
                    Username = username ?? "unknown",
                    Date = dateTime
                });

                unitOfWork.Save();
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

    }
}
