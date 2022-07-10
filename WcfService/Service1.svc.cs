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
        int colorCode;

        public int Connect(string name)
        {
            unitOfWork = new UnitOfWork();

            var foundUser = users.FirstOrDefault(i => i.Name == name);
            string userColor;

            if (foundUser == null) 
            { 
                if (name[0] % 5 == 0)
                {
                    colorCode = 0;
                    userColor = "Red";
                }
                else if (name[0] % 5 == 1)
                {
                    colorCode = 1;
                    userColor = "Green";
                }
                else if (name[0] % 5 == 2)
                {
                    colorCode = 2;
                    userColor = "Blue";
                }
                else
                {
                    colorCode = 3;
                    userColor = "Orange";
                }

                User user = new User()
                {
                    Name = name,
                    operationContext = OperationContext.Current,
                    Color = userColor
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

        public int PassColor()
        {
            return colorCode;
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

        public List<User> Users()
        {
            return (List<User>)unitOfWork.Users.GetAll();
        }

        public List<Message> Messages()
        {
            return (List<Message>)unitOfWork.Messages.GetAll();
        }
    }
}
