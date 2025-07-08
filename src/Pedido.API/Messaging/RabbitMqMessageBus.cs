using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Pedido.API.Messaging;

public class RabbitMqMessageBus : IMessageBus
{
    public void PublicarPedido(object data)
    {
        //var factory = new ConnectionFactory() { HostName = "localhost" };
        var factory = new ConnectionFactory
        {
            HostName = "rabbitmq", // 🟢 nome do serviço no docker-compose
            Port = 5672
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "pedidos", durable: false, exclusive: false, autoDelete: false, arguments: null);
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));

        channel.BasicPublish(exchange: "", routingKey: "pedidos", basicProperties: null, body: body);
    }
}