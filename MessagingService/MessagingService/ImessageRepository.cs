using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingService
{
    interface IMessageRepository
    {
        void AddMessage(string message);
        string GetAll();
    }
}
