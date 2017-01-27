using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessagingService
{
    [ServiceContract(CallbackContract = typeof(IService1Callback))]
    public interface IService1
    {
        [OperationContract]
        Guid LogIn();

        [OperationContract(IsOneWay = true)]
        void LogOut(Guid clientId);

        [OperationContract]
        void SendMessage(Guid clientId, string message);

        [OperationContract]
        string GetHistory();

        [OperationContract]
        void KeepConnection(string client);
    }

    public interface IService1Callback
    {
        [OperationContract(IsOneWay = true)]
        void HandleMessage(string message);
    }
}