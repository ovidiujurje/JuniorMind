using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingService
{
    class SynchedRepository : IMessageRepository
    {
        private IMessageRepository repository;
        private object lockKey;
        public SynchedRepository(IMessageRepository repository)
        {
            this.repository = repository;
        }

        public void AddMessage(string message)
        {
            lock(lockKey)
            {
                repository.AddMessage(message);
            }
        }

        public string GetAll()
        {
            lock (lockKey)
            {
                return repository.GetAll();
            }
        }
    }
}
