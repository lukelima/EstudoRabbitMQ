using RabbitMQ.Client;

namespace EstudoRabbitMQ.Publisher.MessageBroker
{
    public interface IQueueSetup
    {
        void Initialize(IModel channel);
    }
}
