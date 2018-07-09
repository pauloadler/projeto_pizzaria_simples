using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedidoAdicionalInvalidoExcecao : BusinessException
    {
        public ItemPedidoAdicionalInvalidoExcecao() : base("O adicional invalido.")
        {

        }
    }
}
