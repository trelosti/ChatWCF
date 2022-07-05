using ChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonChatContext
{
    public class UserRepository : IRepository<User>
    {
        private ChatContext db;

        public UserRepository(ChatContext db)
        {
            this.db = db;
        }

        public void insertItem(User item)
        {
            db.Users.Add(item);
        }
    }
}
