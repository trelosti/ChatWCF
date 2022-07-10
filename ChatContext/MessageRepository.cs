using ChatModel;
using System.Collections.Generic;

namespace CommonChatContext
{
    public class MessageRepository : IRepository<Message>
    {
        private ChatContext db;

        public MessageRepository(ChatContext db)
        {
            this.db = db;
        }

        public IEnumerable<Message> GetAll()
        {
            return db.Messages;
        }

        public void insertItem(Message item)
        {
            db.Messages.Add(item);
        }

    }
}
