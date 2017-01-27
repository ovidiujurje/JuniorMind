using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace MessagingService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        private readonly Dictionary<Guid, IService1Callback> clients = new Dictionary<Guid, IService1Callback>();

        public void KeepConnection(string client)
        {
            Console.WriteLine(client + " Ping " + DateTime.Now.ToString());
        }

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

        private IMessageRepository history = new SynchedRepository(new FileBasedMessageRepository(@"C:\Users\Ovidiu Jurje\Documents\GitHub\JuniorMind\MessagingService\history.txt"));

        void IService1.SendMessage(Guid clientId, string message)
        {
            BroadcastMessage(message);
            history.AddMessage(message);
        }

        public string GetHistory()
        {
            return history.GetAll();
        }

        public void BroadcastMessage(string message)
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