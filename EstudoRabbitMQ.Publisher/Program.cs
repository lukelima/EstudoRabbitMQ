using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;

var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

IConfiguration configuration = builder.Build();



var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "testuser123",
    Password = "P@ssw0rd!"
};

using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(
            queue: "StudiesQueue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
            );
        Console.WriteLine("How many messages do you want to send ?");
        int numberOfMessages = 0;
        int.TryParse(Console.ReadLine(), out numberOfMessages);
        for(var i = 0; i < numberOfMessages; i++)
        {
            Thread.Sleep(1000);
            var message = $"Message created at {DateTime.Now}";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "StudiesQueue", basicProperties: null, body: body);
            Console.WriteLine($"Message published: {message}");
        }
    }
}