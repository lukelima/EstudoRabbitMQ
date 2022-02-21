using EstudoRabbitMQ.Publisher.Configurations;
using RabbitMQ.Client;

namespace EstudoRabbitMQ.Publisher.MessageBroker
{
    public class QueueConnection : IQueueConnection
    {
        private readonly IConnection _connection;

        public QueueConnection(RabbitMqConfigurations configurations)
        {
            var factory = GetConnection(configurations);
            _connection = factory.CreateConnection();
        }

        public bool IsConnected => _connection != null && _connection.IsOpen;

        public IModel CreateModel()
        {
            if(!IsConnected)
            {
                throw new InvalidOperationException("Não há conexões disponíveis");
            }
            return _connection.CreateModel();
        }

        private ConnectionFactory GetConnection(RabbitMqConfigurations configurations)
            => new ConnectionFactory
            {
                HostName = configurations.Connection.Hostname,
                Port = configurations.Connection.Port,
                UserName = configurations.Connection.Username,
                Password = configurations.Connection.Password,
            };
    }
}
