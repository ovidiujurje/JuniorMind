using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Timers;

namespace MessagingClient1
{
    //[CallbackBehavior(UseSynchronizationContext = false)]
    public partial class Form1 : Form
    {
        private Guid clientId;

        private ServiceReference1.Service1Client service1Client;

        private InstanceContext instanceContext;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var message = "Client 1 said: " + textBox1.Text;

            if (!string.IsNullOrEmpty(message))
            {
                if (service1Client.State == CommunicationState.Faulted)
                {
                    service1Client.Abort();
                    service1Client = new ServiceReference1.Service1Client(instanceContext);
                }

                //service1Client.SendMessage(clientId, message);
                //await SendM(message);
                await Task.Run(() =>
                {
                    SendM(message);
                });


                textBox1.Text = string.Empty;
            }
        }

        private async Task SendM(string message)
        {
            service1Client.SendMessage(clientId, message);
        }

        private void Service1Callback_ClientNotified(object sender, ClientNotifiedEventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.Text += "\n";
            }

            richTextBox1.Text += e.Message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var service1Callback = new Service1Callback();
            service1Callback.ClientNotified += Service1Callback_ClientNotified;

            instanceContext = new InstanceContext(service1Callback);
            service1Client = new ServiceReference1.Service1Client(instanceContext);

            clientId = service1Client.LogIn();

            var timer = new System.Timers.Timer(300000);
            timer.Elapsed +=
            (
            (object o, ElapsedEventArgs args) =>
            {
                    if (service1Client.State == CommunicationState.Faulted)
                    {
                        service1Client.Abort();
                        service1Client = new ServiceReference1.Service1Client(instanceContext);
                    }
            }
            );
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (service1Client != null)
            {
                    if (service1Client.State != CommunicationState.Faulted)
                    {
                        service1Client.LogOut(clientId);
                        service1Client.Close();
                    }
            }
        }
    }

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