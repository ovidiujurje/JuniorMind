using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace MessagingService
{
    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode =ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        private readonly Dictionary<Guid, IService1Callback> clients = new Dictionary<Guid, IService1Callback>();

        Guid IService1.LogIn()
        {
            var callback =
            OperationContext.Current.GetCallbackChannel<IService1Callback>();

            var clientId = Guid.NewGuid();

            if (callback != null)
            {
                lock (clients)
                {
                    clients.Add(clientId, callback);
                }
            }

            return clientId;
        }

        void IService1.LogOut(Guid clientId)
        {
            lock (clients)
            {
                if (clients.ContainsKey(clientId))
                {
                    clients.Remove(clientId);
                }
            }
        }

        void IService1.SendMessage(Guid clientId, string message)
        {
            BroadcastMessage(clientId, message);
        }

        private void BroadcastMessage(Guid clientId, string message)
        {
            ThreadPool.QueueUserWorkItem
                (
                delegate
                {
                    lock (clients)
                    {
                        var disconnectedClientGuids = new List<Guid>();

                        foreach (KeyValuePair<Guid, IService1Callback> client in clients)
                        {
                            try
                            {
                                client.Value.HandleMessage(message);
                            }
                            catch (Exception)
                            {
                                disconnectedClientGuids.Add(client.Key);
                            }
                        }

                        foreach (Guid clientGuid in disconnectedClientGuids)
                        {
                            clients.Remove(clientGuid);
                        }
                    }
                }
                );
        }
    }
}