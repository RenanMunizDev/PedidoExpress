using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Pedido.API.Messaging;
using Pedido.API.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Pedido.API.Tests.Controllers;

public class PedidoControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly Mock<IMessageBus> _busMock = new();

    public PedidoControllerTests(WebApplicationFactory<Program> factory)
    {
        var clientFactory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(_ => _busMock.Object);
            });
        });

        _client = clientFactory.CreateClient();
    }

    [Fact]
    public async Task Post_Pedido_DeveRetornarCreated()
    {
        var pedido = new PedidoModel { Cliente = "Renan", Produto = "Mouse", Quantidade = 1 };
        var content = new StringContent(JsonSerializer.Serialize(pedido), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/Pedidos", content);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        _busMock.Verify(x => x.PublicarPedido(It.IsAny<object>()), Times.Once);
    }
}