using ChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonChatContext
{
    public class MessageRepository : IRepository<Message>
    {
        private ChatContext db;

        public MessageRepository(ChatContext db)
        {
            this.db = db;
        }

        public void insertItem(Message item)
        {
            db.Messages.Add(item);
        }
    }
}
