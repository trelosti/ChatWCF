using ChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IServiceChatCallback))]
    public interface IService1
    {
        [OperationContract]
        void insertUser(User user);
        [OperationContract]
        void insertMessage(Message msg);

        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg, int id);

        [OperationContract]
        string displayString(string str);

    }

    public interface IServiceChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string msg);
    }
}
