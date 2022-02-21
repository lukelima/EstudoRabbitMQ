using EstudoRabbitMQ.Publisher;
using EstudoRabbitMQ.Publisher.MessageBroker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables();

IConfiguration configuration = builder.Build();

var services = new ServiceCollection();
services.ConfigureServices(configuration);
var serviceProvider = services.BuildServiceProvider();
var publisher = serviceProvider.GetRequiredService<IQueuePublisher>();

Console.WriteLine("How many messages do you want to send ?");
int numberOfMessages = 0;
int.TryParse(Console.ReadLine(), out numberOfMessages);
for(var i = 0; i < numberOfMessages; i++)
{
    Thread.Sleep(1000);
    var message = $"Message created at {DateTime.Now}";

    publisher.Publish(message);
    Console.WriteLine($"Message published: {message}");
}
