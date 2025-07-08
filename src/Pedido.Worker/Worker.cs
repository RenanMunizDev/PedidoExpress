using System.Text;
using System.Text.Json;
using Pedido.Worker;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class Worker : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "rabbitmq" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "pedidos", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var pedido = JsonSerializer.Deserialize<PedidoModel>(message);

            Console.WriteLine($"📦 Pedido recebido: {pedido.Cliente} - {pedido.Produto} (Qtd: {pedido.Quantidade})");
        };

        channel.BasicConsume(queue: "pedidos", autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }
}
