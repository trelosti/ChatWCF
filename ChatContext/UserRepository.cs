using ChatModel;
using System.Collections.Generic;

namespace CommonChatContext
{
    public class UserRepository : IRepository<User>
    {
        private ChatContext db;

        public UserRepository(ChatContext db)
        {
            this.db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void insertItem(User item)
        {
            db.Users.Add(item);
        }
    }
}
