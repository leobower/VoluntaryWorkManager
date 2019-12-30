using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralMQManager
{
    public class Publisher : BaseClass, IPublisher
    {
        public void Enqueue(object obj)
        {
            if (base.ValidateHostPort())
            {
                var factory = new ConnectionFactory
                {
                    HostName = base.HostName,
                    Port = base.Port
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(base.QueueName, false, false, false, null);
                        string message = JsonConvert.SerializeObject(obj);
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(String.Empty, base.QueueName, null, body);

                    }

                }
            }
        }
    }
}
