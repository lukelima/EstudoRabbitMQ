using RabbitMQ.Client;

namespace EstudoRabbitMQ.Publisher.MessageBroker
{
    public interface IQueueConnection
    {
        bool IsConnected { get; }
        IModel CreateModel();
    }
}
