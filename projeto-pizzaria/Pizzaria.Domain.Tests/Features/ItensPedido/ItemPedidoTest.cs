using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;

using System;
using System.Collections.Generic;

namespace Pizzaria.Domain.Tests.Features.ItensPedido
{
    [TestFixture]
    public class ItemPedidoTest
    {

        private Mock<Pedido> _pedidoFake;

        private Produto pizzaPequenaCalabresa;
        private Produto pizzaPequenaCoracao;
        private Produto pizzaMediaMussarela;
        private Produto bordaPequenaCatupiry;
        private Produto bordaMediaCheddar;

        [SetUp]
        public void Inicializacao()
        {
            _pedidoFake = new Mock<Pedido>();

            pizzaPequenaCalabresa = ObjectMother.ObterPizzaPequenaDeCalabresa();
            pizzaPequenaCoracao = ObjectMother.ObterPizzaPequenaDeCoracao();
            pizzaMediaMussarela = ObjectMother.ObterPizzaMediaDeMussarela();
            bordaPequenaCatupiry = ObjectMother.ObterBordaPequenaCatupiry();
            bordaMediaCheddar = ObjectMother.ObterBordaMediaCheddar();
        }


        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_pacial_item_pedido_com_1_pizza_pequena_com_1_unico_sabor()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmProduto(_pedidoFake.Object,pizzaPequenaCalabresa);

            double valorEsperado = 60;

            //Action
            double resultado = item.ValorParcial;

            //Assert
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_1_pizza_pequena_com_2_sabores_de_valores_diferentes()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmPizzaComDoisSabores(_pedidoFake.Object, pizzaPequenaCalabresa, pizzaPequenaCoracao);

            double valorEsperado = 70;

            //Action
            double resultado = item.ValorParcial;

            //Assert
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_2_pizzas_pequena_com_o_mesmo_sabor()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmProduto(_pedidoFake.Object, pizzaPequenaCalabresa);
            item.Quantidade = 2;

            double valorEsperado = 120;

            //Action
            double resultado = item.ValorParcial;

            //Assert

            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_1_pizza_pequena_com_1_unico_sabor_com_borda()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmaPizzaComAdicional(_pedidoFake.Object, pizzaPequenaCalabresa, bordaPequenaCatupiry);

            double valorEsperado = 61.25;

            //Action
            double resultado = item.ValorParcial;

            //Assert
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_calcular_valor_parcial_item_pedido_com_1_pizza_pequena_com_2_sabores_com_borda_catupiry()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmPizzaComDoisSaboresEAdicional(_pedidoFake.Object, pizzaPequenaCalabresa, pizzaPequenaCoracao, bordaPequenaCatupiry);

            double valorEsperado = 71.25;

            //Action
            double resultado = item.ValorParcial;

            //Assert
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmProduto(_pedidoFake.Object, pizzaPequenaCalabresa);

            //Action

            Action acao = item.Validar;
            //Assert
            acao.Should().NotThrow<Exception>();
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_pedido_nulo()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmPedidoNulo();

            //Action

            Action acao = item.Validar;
            //Assert
            acao.Should().Throw<ItemPedidoPedidoNullExcecao>();
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_o_primeiro_produto_nulo()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmPrimeiroProdutoNulo(_pedidoFake.Object);

            //Action
            Action acao = item.Validar;

            //Assert
            acao.Should().Throw<ItemPedidoPrimeiroProdutoNuloOuVazioExcecao>();
        }

        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_quantidade_menor_que_1()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmProdutoComQuantidadeMenorQueUm(_pedidoFake.Object, pizzaPequenaCalabresa);

            //Action
            Action acao = item.Validar;

            //Assert
            acao.Should().Throw<ItemPedidoQuantidadeZeroExcecao>();
        }


        [Test]
        public void ItensPedido_Domain_Deve_validar_o_item_pedido_com_adicional_invalido()
        {
            //Arrange
            ItemPedido item = ObjectMother.ObtermItemPedidoComUmaPizzaComAdicional(_pedidoFake.Object, pizzaPequenaCalabresa, pizzaMediaMussarela);

            //Action
            Action acao = item.Validar;

            //Assert
            acao.Should().Throw<ItemPedidoAdicionalInvalidoExcecao>();
        }

    }
}
