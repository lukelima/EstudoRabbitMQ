namespace EstudoRabbitMQ.Publisher.Configurations
{
    public class QueueConfigurations
    {
        public string Queue { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
    }
}
