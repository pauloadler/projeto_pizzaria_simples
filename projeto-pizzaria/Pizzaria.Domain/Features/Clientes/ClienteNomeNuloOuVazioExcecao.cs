using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Clientes
{
    public class ClienteNomeNuloOuVazioExcecao : BusinessException
    {
        public ClienteNomeNuloOuVazioExcecao() : base("O nome não pode ser nulo ou vazio!")
        {
        }
    }
}
