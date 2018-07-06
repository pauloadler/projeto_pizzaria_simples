using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Produtos
{
    public class ProdutoDescricaoNulaOuVaziaExcecao : BusinessException
    {
        public ProdutoDescricaoNulaOuVaziaExcecao() : base("A descrição não pode ser nula e nem vazia!")
        {
        }
    }
}
