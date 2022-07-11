using ChatModel;
using System.Collections.Generic;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IServiceChatCallback))]
    public interface IService1
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg, int id);
        [OperationContract]
        List<User> Users();
        [OperationContract]
        List<Message> Messages();

    }

    public interface IServiceChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string msg);
    }
}
