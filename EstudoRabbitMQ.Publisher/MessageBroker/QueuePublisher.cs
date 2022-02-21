using EstudoRabbitMQ.Publisher.Configurations;
using System.Text;

namespace EstudoRabbitMQ.Publisher.MessageBroker
{
    public class QueuePublisher : IQueuePublisher
    {
        private readonly IQueueConnection _connection;
        private readonly string _exchangeName;
        private readonly string _queueName;

        public QueuePublisher(
            IQueueConnection connection, 
            IQueueSetup queueSetup,
            RabbitMqConfigurations configurations)
        {
            _exchangeName = configurations.ExchangeName;
            _queueName = configurations.QueueName;
            _connection = connection;
            using (var channel = _connection.CreateModel())
            {
                queueSetup.Initialize(channel);
            }
        }

        public void Publish(string message)
        {
            var messageBody = Encoding.UTF8.GetBytes(message);
            using (var channel = _connection.CreateModel())
            {
                channel.ConfirmSelect();
                var props = channel.CreateBasicProperties();
                props.DeliveryMode = 2; // persistent
                if(props.Headers is null)
                {
                    props.Headers = new Dictionary<string, object>
                    {
                        ["content-type"] = "application/json"
                    };
                }
                channel.BasicPublish(
                    exchange: _exchangeName,
                    routingKey: _queueName,
                    mandatory: true,
                    basicProperties: props,
                    body: messageBody);
            }
        }
    }
}
