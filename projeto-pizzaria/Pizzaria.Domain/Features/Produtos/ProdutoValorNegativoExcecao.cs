using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Produtos
{
    public class ProdutoValorNegativoExcecao : BusinessException
    {
        public ProdutoValorNegativoExcecao() : base("O valor do produto não pode ser negativo")
        {
        }
    }
}
