namespace Pedido.API.Models;

public class PedidoModel
{
    public string Cliente { get; set; } = string.Empty;
    public string Produto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
}
