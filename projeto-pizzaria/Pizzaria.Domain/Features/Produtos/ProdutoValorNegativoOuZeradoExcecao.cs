using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.Produtos
{
    public class ProdutoValorNegativoOuZeradoExcecao : BusinessException
    {
        public ProdutoValorNegativoOuZeradoExcecao() : base("O valor do produto não pode ser negativo")
        {
        }
    }
}
