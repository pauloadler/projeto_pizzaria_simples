using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Enderecos
{
    public class EnderecoUFNuloOuVazioExcecao : BusinessException
    {
        public EnderecoUFNuloOuVazioExcecao() : base("O UF não pode ser nulo ou vazio!")
        {
        }
    }
}
