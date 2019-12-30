using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace CentralMQManager
{
    public abstract class Subscriber : BaseClass
    {
        private Action<string> _doWork;
        public Action<string> DoWork { get => _doWork; set => _doWork = value; }

        public void StartListening()
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
                        var consumer = new EventingBasicConsumer(channel);

                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            DoWork(message);
                        };
                        channel.BasicConsume(base.QueueName, true, consumer);
                    }
                }
            }
            else
            {
                throw new Exception("Provide information for HostName, Port and QueueName properties");
            }
        }

    }
}
