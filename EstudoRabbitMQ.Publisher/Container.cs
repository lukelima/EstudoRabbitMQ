using EstudoRabbitMQ.Publisher.Configurations;
using EstudoRabbitMQ.Publisher.MessageBroker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EstudoRabbitMQ.Publisher
{
    public static class Container
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitmqConfig = configuration.GetSection("RabbitMQ").Get<RabbitMqConfigurations>();
            services.AddSingleton(rabbitmqConfig);

            services.AddScoped<IQueueConnection, QueueConnection>();
            services.AddScoped<IQueueSetup, QueueSetup>();

            services.AddScoped<IQueuePublisher, QueuePublisher>();
            return services;
        }
    }
}
