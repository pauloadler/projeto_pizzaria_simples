using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Infra.CNPJs;
using Pizzaria.Infra.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzaria.Domain.Features.Clientes
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string NumeroDocumento { get; set; }
        public virtual Endereco Endereco { get; set; }
        public TipoClienteEnum TipoCliente { get; set; }
       

        public void AdicionarDocumento(TipoClienteEnum TipoCliente, string numeroDocumento)
        {
            // Cpf Cpf 
            // Cnpj Cnpj 
        }
    }
}