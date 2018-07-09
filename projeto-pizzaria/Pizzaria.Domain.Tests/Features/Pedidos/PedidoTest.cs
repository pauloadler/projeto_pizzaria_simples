using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;

namespace Pizzaria.Domain.Tests.Features.Pedidos
{
    [TestFixture]
    public class PedidoTest
    {
        private Mock<Cliente> pessoaFake;
        private Mock<Cliente> empresaFake;

        private Produto pizzaPequenaCalabresa;
        private Produto pizzaPequenaCoracao;
        private Produto pizzaMediaMussarela;
        private Produto bordaPequenaCatupiry;
        private Produto bordaMediaCheddar;

        private Pedido pedido;
        private List<ItemPedido> itensPedidos;


        [SetUp]
        public void Inicializacao()
        {
            pessoaFake = new Mock<Cliente>();
            pessoaFake.Object.TipoCliente = TipoClienteEnum.Fisico;

            empresaFake = new Mock<Cliente>();
            empresaFake.Object.TipoCliente = TipoClienteEnum.Juridico;

            pizzaPequenaCalabresa = ObjectMother.ObterPizzaPequenaDeCalabresa();

            pizzaPequenaCoracao = ObjectMother.ObterPizzaPequenaDeCoracao();
            pizzaMediaMussarela = ObjectMother.ObterPizzaMediaDeMussarela();
            bordaPequenaCatupiry = ObjectMother.ObterBordaPequenaCatupiry();
            bordaMediaCheddar = ObjectMother.ObterBordaMediaCheddar();

            itensPedidos = new List<ItemPedido>();
            itensPedidos.Add(new ItemPedido { PrimeiroProduto = pizzaMediaMussarela});
        }


        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_1_unico_sabor()
        {
            //Arrange
            pedido = ObjectMother.ObterPedidoSemUmaListaItens(pessoaFake.Object);

            int quantidade = 1;
            double valorEsperado = 60;
            int tamanhoEsperado = 1;

            //Action
            pedido.AdicionarPizza(quantidade, pizzaPequenaCalabresa);
            double resultado = pedido.ValorTotal;

            //Assert
            pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_2_sabores_de_valores_diferentes()
        {
            //Arrange
            pedido = ObjectMother.ObterPedidoSemUmaListaItens(pessoaFake.Object);

            int quantidade = 1;
            double valorEsperado = 70;
            int tamanhoEsperado = 1;

            //Action
            pedido.AdicionarPizza(quantidade, pizzaPequenaCalabresa, pizzaPequenaCoracao);
            double resultado = pedido.ValorTotal;

            //Assert
            pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_2_pizzas_pequena_com_1_sabor_cada()
        {
            //Arrange
            pedido = ObjectMother.ObterPedidoSemUmaListaItens(pessoaFake.Object);

            int quantidade = 1;
            double valorEsperado = 130;
            int tamanhoEsperado = 2;

            //Action
            pedido.AdicionarPizza(quantidade, pizzaPequenaCalabresa);
            pedido.AdicionarPizza(quantidade, pizzaPequenaCoracao);
            double resultado = pedido.ValorTotal;

            //Assert
            pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_1_unico_sabor_com_borda()
        {
            //Arrange
            pedido = ObjectMother.ObterPedidoSemUmaListaItens(pessoaFake.Object);

            int quantidade = 1;
            double valorEsperado = 61.25;
            int tamanhoEsperado = 1;

            //Action
            pedido.AdicionarPizza(quantidade, pizzaPequenaCalabresa, null, bordaPequenaCatupiry);
            double resultado = pedido.ValorTotal;

            //Assert
            pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_2_sabores_com_borda_catupiry_e_1_pizza_media_com_2_sabores_com_borda_cheedar()
        {
            //Arrange
            pedido = ObjectMother.ObterPedidoSemUmaListaItens(pessoaFake.Object);
            Produto pizzaMediaCalabresa = ObjectMother.ObterPizzaMediaDeCalabresa();
          
            int quantidade = 1;
            double valorEsperado = 147.75;
            int tamanhoEsperado = 2;

            //Action
            pedido.AdicionarPizza(quantidade, pizzaPequenaCalabresa, pizzaPequenaCoracao, bordaPequenaCatupiry);
            pedido.AdicionarPizza(quantidade, pizzaMediaMussarela, pizzaMediaCalabresa, bordaMediaCheddar);
            double resultado = pedido.ValorTotal;

            //Assert
            pedido.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_1_calzone()
        {
            //Arrange
            pedido = ObjectMother.ObterPedidoSemUmaListaItens(pessoaFake.Object);
            Produto calzone = ObjectMother.ObterCalzone();

            int quantidadeCalzone = 1;
            int quantidadePizza = 1;
            double valorEsperado = 75.00;
            int tamanhoLista = 2;

            //Action
            pedido.AdicionarCalzone(quantidadeCalzone, calzone);
            pedido.AdicionarPizza(quantidadePizza, pizzaPequenaCalabresa);
            double resultado = pedido.ValorTotal;

            //Assert
            pedido.ItensPedidos.Should().HaveCount(tamanhoLista);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_1_bebida()
        {
            //Arrange
            pedido = ObjectMother.ObterPedidoSemUmaListaItens(pessoaFake.Object);
            Produto bebida = ObjectMother.ObterBebida();
            
            int quantidadeBebida = 1;
            int quantidadePizza = 1;
            double valorEsperado = 68.00;

            //Action
            pedido.AdicionarBebida(quantidadeBebida, bebida);
            pedido.AdicionarPizza(quantidadePizza, pizzaPequenaCalabresa);
            double resultado = pedido.ValorTotal;

            //Assert
            pedido.ItensPedidos.Should().HaveCount(2);
            resultado.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoComUmaListaItens(pessoaFake.Object, itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().NotThrow<Exception>();
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_o_cliente_nulo()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoComClienteNulo(itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoClienteNuloExcecao>();
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_data_menor_que_atual()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoDataMenorQueAtual(pessoaFake.Object, itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoDataMenorQueAtualExcecao>();
        }


        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_lista_de_itens_vazia()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoSemUmaListaItens(pessoaFake.Object);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoItensPedidosVazioExcecao>();
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_setor_nulo_ou_vazio()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoSetorNuloOuVazio(empresaFake.Object, itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoSetorNuloOuVazioExcecao>();
        }

        [Test]
        public void Pedidos_Domain_Deve_validar_o_pedido_com_responsavel_nulo_ou_vazio()
        {
            //Arrange
            Pedido pedido = ObjectMother.ObterPedidoResponsavelNuloOuVazio(empresaFake.Object, itensPedidos);

            //Action
            Action acao = pedido.Validar;

            //Assert
            acao.Should().Throw<PedidoResponsavelNuloOuVazioExcecao>();
        }
    }
}
