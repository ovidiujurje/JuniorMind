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

                await Task.Run(() =>
                {
                    service1Client.SendMessage(clientId, message);
                });

                textBox1.Text = string.Empty;
            }
        }

        private void GetMessages(object sender, ClientNotifiedEventArgs e)
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
            service1Callback.ClientNotified += GetMessages;

            instanceContext = new InstanceContext(service1Callback);
            service1Client = new ServiceReference1.Service1Client(instanceContext);

            clientId = service1Client.LogIn();

            richTextBox1.Text = service1Client.GetHistory();

            var timer = new System.Timers.Timer(3000);
            timer.Elapsed += new ElapsedEventHandler
            (
            (object o, ElapsedEventArgs args) =>
            {
                if (service1Client.State == CommunicationState.Faulted)
                {
                    service1Client.Abort();
                    service1Client = new ServiceReference1.Service1Client(instanceContext);
                }
                service1Client.KeepConnection("Client 1");
            }
            );
            timer.Enabled = true;
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
}