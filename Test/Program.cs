using CommonChatContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatModel;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.Users.insertItem(new ChatModel.User
            {
                ID = 1,
                Name = "Joe"
            });



            unitOfWork.Messages.insertItem(new ChatModel.Message
            {
                UserId = 1,
                Username = "Joe",
                Msg = "check",
                Date = DateTime.Now,
            });

            unitOfWork.Save();
        }
    }
}
