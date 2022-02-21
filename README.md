# EstudoRabbitMQ
Repositório proveniente de estudos sobre RabbitMQ.

## ⚠️Atenção
Para fazer a aplicação funcionar, suba um container docker com a imagem do rabbit mq usando o seguinte comando:
```
docker run -d --hostname rabbit-local --name testes-rabbitmq -p 5672:5672 -p 15672:15672 -e RABBITMQ_DEFAULT_USER=testuser123 -e RABBITMQ_DEFAULT_PASS=P@ssw0rd! rabbitmq:3-management
```

## Fontes e referências
* [.NET Core 2.1 + ASP.NET Core 2.1 + RabbitMQ: exemplos utilizando mensageria](https://renatogroffe.medium.com/net-core-2-1-asp-net-core-2-1-rabbitmq-exemplos-utilizando-mensageria-3e1427133167);
* [Mensageria + .NET Core 3.1: exemplos com RabbitMQ, Kafka, Azure Service Bus e Azure Queue Storage](https://renatogroffe.medium.com/mensageria-net-core-3-1-exemplos-com-rabbitmq-kafka-azure-service-bus-e-azure-queue-storage-c594bf30c091);
* [Dead letter queue configuration with RabbitMQ](https://zoltanaltfatter.com/2016/09/06/dead-letter-queue-configuration-rabbitmq/);
* [rabbitmq-message-ttl](https://github.com/poferrari/rabbitmq-message-ttl)
