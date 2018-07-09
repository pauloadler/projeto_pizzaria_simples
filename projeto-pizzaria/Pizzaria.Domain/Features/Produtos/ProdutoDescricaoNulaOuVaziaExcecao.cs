using Pizzaria.Domain.Exceptions;

namespace Pizzaria.Domain.Features.Produtos
{
    public class ProdutoDescricaoNulaOuVaziaExcecao : BusinessException
    {
        public ProdutoDescricaoNulaOuVaziaExcecao() : base("A descrição não pode ser nula e nem vazia!")
        {
        }
    }
}
