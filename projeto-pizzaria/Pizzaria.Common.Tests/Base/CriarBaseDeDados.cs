using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
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
            Endereco endereco = ObjectMother.ObterEndereco();
            Cliente clienteFisico = ObjectMother.ObterClienteTipoPessoaFisica(endereco);
            Cliente clienteJuridico = ObjectMother.ObterClienteTipoPessoaJuridica(endereco);
            Cliente clienteComPedido = ObjectMother.ObterClienteTipoPessoaFisica(endereco);

            Produto calzone = ObjectMother.ObterCalzone();
            Produto pizzaMediaDeCalabresa = ObjectMother.ObterPizzaMediaDeCalabresa();

            Pedido pedido = ObjectMother.ObterPedidoSemUmaListaItens(clienteComPedido);
            pedido.AdicionarPizza(1, pizzaMediaDeCalabresa);

            contexto.Clientes.Add(clienteFisico);
            contexto.Clientes.Add(clienteJuridico);
            contexto.Clientes.Add(clienteComPedido);
            contexto.Produtos.Add(calzone);
            contexto.Produtos.Add(pizzaMediaDeCalabresa);
            contexto.Pedidos.Add(pedido);

            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}
