using System;
using System.Collections.Generic;
using System.Text;

namespace CentralMQManager
{
    public interface IPublisher
    {
        string HostName { get; set; }
        int Port { get; set; }
        string QueueName { get; set; }

        void Enqueue(object obj);
    }
}
