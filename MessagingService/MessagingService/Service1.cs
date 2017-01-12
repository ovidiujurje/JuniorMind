﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace MessagingService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
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

