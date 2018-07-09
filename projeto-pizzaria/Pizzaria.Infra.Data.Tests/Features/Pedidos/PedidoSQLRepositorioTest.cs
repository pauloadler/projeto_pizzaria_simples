using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data.Features.Pedidos;
using Pizzaria.Infra.Data.Features.Produtos;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Tests.Features.Pedidos
{
    [TestFixture]
    public class PedidoSQLRepositorioTest
    {
        private IPedidoRepositorio _repositorio;
        private Cliente cliente;
        private DataContext _contexto;
        private Produto calzone;

        [SetUp]
        public void Inicializacao()
        {
            _contexto = new DataContext();
            Database.SetInitializer(new CriarBaseDeDados());
            _contexto.Database.Initialize(true);

            _repositorio = new PedidoSQLRepositorio(_contexto);

            cliente = ObjectMother.ObterClienteTipoPessoaFisica(ObjectMother.ObterEndereco());
            cliente.Id = 1;

            calzone = ObjectMother.ObterCalzone();
        }

        [Test]
        public void Pedidos_InfraData_Deve_salvar_um_pedido()
        {
            //Cenário
            Pedido pedido = ObjectMother.GetPedidoSemUmaListaItens(cliente);

            long idExperado = 2;
            int quantidade = 3;
            int maoirQue = 0;

            //Ação
            pedido.AdicionarCalzone(quantidade, calzone);
            Pedido resultado = _repositorio.Salvar(pedido);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idExperado);
            resultado.Cliente.Should().NotBeNull();
            resultado.ItensPedidos.Should().HaveCountGreaterThan(maoirQue);
        }

        [Test]
        public void Pedidos_InfraData_Deve_buscar_por_id_um_pedido()
        {
            //Cenário
            long idEsperado = 1;
            int maoirQue = 0;

            //Ação
            Pedido resultado = _repositorio.BuscarPorId(idEsperado);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idEsperado);
            resultado.Cliente.Should().NotBeNull();
            resultado.ItensPedidos.Should().HaveCountGreaterThan(maoirQue);
        }

        [Test]
        public void Pedidos_InfraData_Deve_atualizar_um_pedido()
        {
            //Cenario
            long idProcura = 1;
            StatusPedidoEnum novoStatus = StatusPedidoEnum.EmEntrega;
            Pedido pedido = _repositorio.BuscarPorId(idProcura);
            pedido.StatusPedido = novoStatus;

            //Ação
            var resultado = _repositorio.Atualizar(pedido);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.StatusPedido.Should().Equals(novoStatus);
        }

        [Test]
        public void Pedidos_InfraData_Deve_buscar_por_todos_pedidos()
        {
            //Cenario
            int tamanhoLista = 1;

            //Ação
            var lista = _repositorio.Listagem();

            //Verifica
            lista.Should().NotBeNull();
            lista.Should().HaveCount(tamanhoLista);
        }

        [Test]
        public void Pedidos_InfraData_Deve_deletar_um_pedido()
        {
            //Cenário
            long idPedido = 1;
            var pedido = _repositorio.BuscarPorId(idPedido);

            //Ação
            _repositorio.Excluir(pedido);

            //Verifica
            var pedidoDB = _repositorio.BuscarPorId(idPedido);
            pedidoDB.Should().BeNull();

        }
    }
}
