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
using System.Threading;

namespace MessagingClient1
{
    //[CallbackBehavior(UseSynchronizationContext = false)]
    public partial class Form1 : Form, ServiceReference1.IService1Callback
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var instanceContext = new InstanceContext(this);
            var client = new ServiceReference1.Service1Client(instanceContext);
            client.GetData(textBox1.Text);
        }

        public void AddMessage(string history)
        {
            if (listBox1.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                Invoke(d, new object[] { history });
            }
            else
            {
                listBox1.Text = history;
            }
            SetText(history);
        }

        private void SetText(string text)
        {
            this.listBox1.Text = text;
        }


    }

    delegate void SetTextCallback(string text);
}
