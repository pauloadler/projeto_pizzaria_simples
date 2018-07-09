using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedidoPrimeiroProdutoNuloOuVazioExcecao : BusinessException
    {
        public ItemPedidoPrimeiroProdutoNuloOuVazioExcecao() : base("O primeiro produto do item de pedido não pode ser nulo ou vazio.")
        {
        }
    }
}
