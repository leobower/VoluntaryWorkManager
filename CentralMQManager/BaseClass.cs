using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralMQManager
{
    public abstract class BaseClass
    {
        private string _hostName;
        private int _port;
        private string _queueName;

        public string HostName { get => _hostName; set => _hostName = value; }
        public int Port { get => AmqpTcpEndpoint.UseDefaultPort; set => _port = value; }
        public string QueueName { get => _queueName; set => _queueName = value; }

        public bool ValidateHostPort()
        {
            return !String.IsNullOrEmpty(HostName) && !Port.Equals(0) && !String.IsNullOrEmpty(QueueName);
        }
    }
}
