using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CommonChatContext
{
    public interface IRepository<T> where T : class
    {

        void insertItem(T item);
    }
}
