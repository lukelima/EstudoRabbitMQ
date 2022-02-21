namespace EstudoRabbitMQ.Publisher.Configurations
{
    public class RabbitMqConfigurations
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
        public string ExchangeName { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
    }
}
