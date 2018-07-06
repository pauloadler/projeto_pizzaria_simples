using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Clientes
{
    public class ClienteTipoClienteInvalidoExcecao : BusinessException
    {
        public ClienteTipoClienteInvalidoExcecao() : base("O cliente deve conter um tipo!")
        {
        }
    }
}
