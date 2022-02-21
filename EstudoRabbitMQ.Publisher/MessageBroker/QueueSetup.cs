using EstudoRabbitMQ.Publisher.Configurations;
using RabbitMQ.Client;

namespace EstudoRabbitMQ.Publisher.MessageBroker
{
    public class QueueSetup : IQueueSetup
    {
        private readonly RabbitMqConfigurations _configurations;

        public QueueSetup(RabbitMqConfigurations configurations)
        {
            _configurations = configurations;
        }

        public void Initialize(IModel channel)
        {
            channel.ExchangeDeclare(_configurations.ExchangeName, "topic", durable: true, autoDelete: false, arguments: new Dictionary<string, object>
            {
                ["x-queue-mode"] = "lazy"
            });

            channel.QueueDeclare(_configurations.QueueName, durable: true, autoDelete: false, exclusive: false, arguments: new Dictionary<string, object>
            {
                ["x-queue-mode"] = "lazy"
            });
            channel.QueueBind(_configurations.QueueName, _configurations.ExchangeName, _configurations.QueueName); // todo: adicionar routing key
        }
    }
}
