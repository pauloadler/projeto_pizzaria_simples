using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Pedidos
{
    public class PedidoDataMenorQueAtualExcecao : BusinessException
    {
        public PedidoDataMenorQueAtualExcecao() : base("O data não pode ser menor que a data do sisteme.")
        {
        }
    }
}
