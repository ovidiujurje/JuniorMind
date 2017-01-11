using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public void GetData(string value)
        {
            var history = string.Empty;
            history += Environment.NewLine + value; 
            OperationContext.Current.GetCallbackChannel<IService1Callback>().AddMessage(history);
        }
    }
}
