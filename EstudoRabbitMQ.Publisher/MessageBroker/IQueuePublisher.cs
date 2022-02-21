namespace EstudoRabbitMQ.Publisher.MessageBroker
{
    public interface IQueuePublisher
    {
        void Publish(string message);
    }
}
