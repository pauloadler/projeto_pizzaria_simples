using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Application.Features.ItensPedido;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data;
using Pizzaria.Infra.Data.Features.ItensPedido;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Pizzaria.Integration.Tests.ItensPedido
{
    [TestFixture]
    public class ItensPedidoIntegracaoTest
    {
        private DataContext _contexto;

        private IItemPedidoRepositorio _repositorio;
        private ItensPedidoServico _servico;
        private ItemPedido _itemPedido;

        [SetUp]
        public void Inicializacao()
        {
            Database.SetInitializer(new CriarBaseDeDados());
            _contexto = new DataContext();
            _contexto.Database.Initialize(true);

            _repositorio = new ItemPedidoSQLRepositorio(_contexto);

            _servico = new ItensPedidoServico(_repositorio);

        }

        [Test]
        public void ItensPedido_Integration_Deve_exluir_um_item_pedido_com_sucesso()
        {
            //Cenário
            long idProcura = 1;
            _itemPedido = _servico.BuscarPorId(idProcura);

            //Ação
            _servico.Excluir(_itemPedido);

            //Verificação
            ItemPedido resultado = _servico.BuscarPorId(idProcura);
            resultado.Should().BeNull();
        }

        [Test]
        public void ItensPedido_Integration_Nao_deve_exluir_um_item_pedido_com_id_invalido()
        {
            //Cenário
            _itemPedido.Id = 0;

            //Ação
            Action acao = () => _servico.Excluir(_itemPedido);

            //Verificação
            acao.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void ItensPedido_Integration_Deve_buscar_por_id_um_item_pedido()
        {
            //Cenário
            long idProcura = 1;
            //Ação
            ItemPedido item = _servico.BuscarPorId(idProcura);

            //Verificação
            item.Should().NotBeNull();
        }

        [Test]
        public void ItensPedido_Integration_Nao_deve_buscar_por_id_um_item_pedido_com_chave_de_produra_invalida()
        {
            //Cenário
            long idProcura = 0;

            //Ação
            Action acao = () => _servico.BuscarPorId(idProcura);

            //Verificação
            acao.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void ItensPedido_Integration_Deve_listar_os_item_pedido()
        {
            //Cenário
            int tamanhoEsperado = 1;

            //Ação
            var lista = _servico.Listagem();

            //Verificação
            lista.Should().NotBeNull();
            lista.Should().HaveCount(tamanhoEsperado);

        }

    }
}
