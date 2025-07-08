namespace Pedido.API.Messaging;

public interface IMessageBus
{
    void PublicarPedido(object data);
}