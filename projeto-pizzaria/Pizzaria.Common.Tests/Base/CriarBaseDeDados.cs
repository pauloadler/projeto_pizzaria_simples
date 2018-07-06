using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.CNPJs;
using Pizzaria.Infra.CPFs;
using Pizzaria.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Common.Tests.Base
{
    public class CriarBaseDeDados : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext contexto)
        {
            Cpf cpf = ObjectMother.GetCpf();
            Cnpj cnpj = ObjectMother.GetCnpj();
            Endereco endereco = ObjectMother.GetEndereco();
            Cliente clienteFisico = ObjectMother.ObterClienteTipoPessoaFisica(endereco);
            Cliente clienteJuridico = ObjectMother.ObterClienteTipoPessoaJuridica(endereco);

            contexto.Clientes.Add(clienteFisico);
            contexto.Clientes.Add(clienteJuridico);

            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}
