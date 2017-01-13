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
        [OperationContract(IsOneWay = true)]
        void GetData(string value);
    }

    public interface IService1Callback
    {
        [OperationContract(IsOneWay = true)]
        void AddMessage(string history);
    }
}