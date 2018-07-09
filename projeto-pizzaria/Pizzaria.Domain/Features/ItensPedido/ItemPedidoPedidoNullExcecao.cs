using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedidoPedidoNullExcecao : BusinessException
    {
        public ItemPedidoPedidoNullExcecao() : base("A pedido não pode ser nulo.")
        {
        }
    }
}
