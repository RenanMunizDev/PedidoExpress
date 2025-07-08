using Pedido.API.Models;
using Xunit;

namespace Pedido.API.Tests.Models
{
    public class PedidoModelTests
    {
        [Fact]
        public void PedidoModel_DeveCriarComValoresCorretos()
        {
            var pedido = new PedidoModel
            {
                Cliente = "Renan Muniz",
                Produto = "Café",
                Quantidade = 3
            };

            Assert.Equal("Renan Muniz", pedido.Cliente);
            Assert.Equal("Café", pedido.Produto);
            Assert.Equal(3, pedido.Quantidade);
        }
    }
}
