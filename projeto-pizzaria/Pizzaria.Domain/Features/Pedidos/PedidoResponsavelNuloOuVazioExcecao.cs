﻿using Pizzaria.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Pedidos
{
    public class PedidoResponsavelNuloOuVazioExcecao : BusinessException
    {
        public PedidoResponsavelNuloOuVazioExcecao() : base("O responsavel não pode ser nulo ou vazio.")
        {
        }
    }
}
