using ChatModel;
using System.Data.Entity;

namespace CommonChatContext
{
    public class ChatContext : DbContext
    {
        public ChatContext() : base("dbCon")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
