using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingService
{
    class FileBasedMessageRepository : IMessageRepository
    {
        private readonly string path;

        public FileBasedMessageRepository(string path)
        {
            this.path = path;
        }

        public void AddMessage(string message)
        {
            File.AppendAllLines(path, new[] { message });    
        }

        public string GetAll()
        {
            return File.ReadAllText(path);
        }
    }
}
