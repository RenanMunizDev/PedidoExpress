using Microsoft.AspNetCore.Mvc;
using Pedido.API.Models;
using Pedido.API.Messaging;

namespace Pedido.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IMessageBus _bus;

    public PedidosController(IMessageBus bus)
    {
        _bus = bus;
    }

    [HttpPost]
        public IActionResult Post([FromBody] PedidoModel pedido)
        {
            try
            {
                _bus.PublicarPedido(pedido);
                return Created("", pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
}
