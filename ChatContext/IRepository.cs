using System.Collections.Generic;

namespace CommonChatContext
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void insertItem(T item);
    }
}
