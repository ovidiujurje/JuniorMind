using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingClient1
{
    public class Service1Callback : ServiceReference1.IService1Callback
    {
        public event ClientNotifiedEventHandler ClientNotified;

        void ServiceReference1.IService1Callback.HandleMessage(string message)
        {
            if (ClientNotified != null)
            {
                ClientNotified(this, new ClientNotifiedEventArgs(message));
            }
        }
    }

    public delegate void ClientNotifiedEventHandler(object sender, ClientNotifiedEventArgs e);

    public class ClientNotifiedEventArgs : EventArgs
    {
        private readonly string message;

        public ClientNotifiedEventArgs(string message)
        {
            this.message = message;
        }

        public string Message { get { return message; } }
    }
}
