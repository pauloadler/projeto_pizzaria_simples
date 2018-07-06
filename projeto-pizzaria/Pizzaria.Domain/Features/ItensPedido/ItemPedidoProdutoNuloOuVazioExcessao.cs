using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedidoProdutoNuloOuVazioExcessao : BusinessException
    {
        public ItemPedidoProdutoNuloOuVazioExcessao() : base("O Produto do item de pedido não pode ser nulo ou vazio.")
        {
        }
    }
}
