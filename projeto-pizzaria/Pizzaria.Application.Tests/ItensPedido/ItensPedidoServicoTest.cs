using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Application.Features.ItensPedido;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;

namespace Pizzaria.Application.Tests.ItensPedido
{
    [TestFixture]
    public class ItensPedidoServicoTest
    {
        private Mock<IItemPedidoRepositorio> _repositorio;
        private Mock<Produto> _produtoFake;
        private Mock<Pedido> _pedidoFake;
     
        private ItensPedidoServico _servico;
        private ItemPedido _itemPedido;

        [SetUp]
        public void Inicializacao()
        {
            _repositorio = new Mock<IItemPedidoRepositorio>();
            _produtoFake = new Mock<Produto>();
            _pedidoFake = new Mock<Pedido>();

            _servico = new ItensPedidoServico(_repositorio.Object);

            _itemPedido = ObjectMother.ObtermItemPedidoComUmProduto(_pedidoFake.Object, _produtoFake.Object);
            _itemPedido.Id = 1;
        }

        [Test]
        public void ItensPedido_Application_Deve_exluir_um_item_pedido_com_sucesso()
        {
            //Cenário
            _repositorio.Setup(x => x.Excluir(_itemPedido));

            //Ação
            _servico.Excluir(_itemPedido);

            //Verificação
            _repositorio.Verify(x => x.Excluir(_itemPedido));
        }

        [Test]
        public void ItensPedido_Application_Nao_deve_exluir_um_item_pedido_com_id_invalido()
        {
            //Cenário
            _itemPedido.Id = 0;

            //Ação
             Action acao = () => _servico.Excluir(_itemPedido);

            //Verificação
            acao.Should().Throw<IdentifierUndefinedException>();
            _repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void ItensPedido_Application_Deve_buscar_por_id_um_item_pedido()
        {
            //Cenário
            long idProcura = 1;
            _repositorio.Setup(x => x.BuscarPorId(idProcura)).Returns(_itemPedido);

            //Ação
            ItemPedido item = _servico.BuscarPorId(idProcura);

            //Verificação
            item.Should().NotBeNull();
            _repositorio.Verify(x => x.BuscarPorId(idProcura));
        }

        [Test]
        public void ItensPedido_Application_Nao_deve_buscar_por_id_um_item_pedido_com_chave_de_produra_invalida()
        {
            //Cenário
            long idProcura = 0;

            //Ação
            Action acao = () => _servico.BuscarPorId(idProcura);

            //Verificação
            acao.Should().Throw<IdentifierUndefinedException>();
            _repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void ItensPedido_Application_Deve_listar_os_item_pedido()
        {
            //Cenário
            _repositorio.Setup(x => x.Listagem()).Returns(new List<ItemPedido>());

            //Ação
            var lista = _servico.Listagem();

            //Verificação
            lista.Should().NotBeNull();
            _repositorio.Verify(x => x.Listagem());
        }

    }
}
