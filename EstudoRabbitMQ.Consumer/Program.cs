using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

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
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += ReadMessage;
        channel.BasicConsume(queue: "StudiesQueue", autoAck: true, consumer: consumer);

        Console.WriteLine("Aguardando mensagens para processamento...");
        Console.WriteLine("Pressione uma tecla para encerrar.");
        Console.ReadKey();
    }
}

static void ReadMessage(object sender, BasicDeliverEventArgs e)
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine($"[Message received]: {message}");

}