using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;

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

        private Pedido pedidoSemItens;
        

        [SetUp]
        public void Inicializacao()
        {
            pessoaFake = new Mock<Cliente>();
            empresaFake = new Mock<Cliente>();

            pedidoSemItens = ObjectMother.GetPedidoSemUmaListaItens(pessoaFake.Object);

            pizzaPequenaCalabresa = ObjectMother.ObterPizzaPequenaDeCalabresa();

            pizzaPequenaCoracao = ObjectMother.ObterPizzaPequenaDeCoracao();
            pizzaMediaMussarela = ObjectMother.ObterPizzaMediaDeMussarela();
            bordaPequenaCatupiry = ObjectMother.ObterBordaPequenaCatupiry();
            bordaMediaCheddar = ObjectMother.ObterBordaMediaCheddar();
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_1_unico_sabor()
        {
            //Arrange
            int quantidade = 1;
            double valorEsperado = 60;
            int tamanhoEsperado = 1;

            //Action
            pedidoSemItens.AdicionarPizza(quantidade, pizzaPequenaCalabresa);

            //Assert
            pedidoSemItens.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            pedidoSemItens.ValorTotal.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_2_sabores_de_valores_diferentes()
        {
            //Arrange
            int quantidade = 1;
            double valorEsperado = 70;
            int tamanhoEsperado = 1;

            //Action
            pedidoSemItens.AdicionarPizza(quantidade, pizzaPequenaCalabresa, pizzaPequenaCoracao);

            //Assert
            pedidoSemItens.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            pedidoSemItens.ValorTotal.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_2_pizzas_pequena_com_1_sabor_cada()
        {
            //Arrange
            int quantidade = 1;
            double valorEsperado = 130;
            int tamanhoEsperado = 2;

            //Action
            pedidoSemItens.AdicionarPizza(quantidade, pizzaPequenaCalabresa);
            pedidoSemItens.AdicionarPizza(quantidade, pizzaPequenaCoracao);

            //Assert
            pedidoSemItens.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            pedidoSemItens.ValorTotal.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_1_unico_sabor_com_borda()
        {
            //Arrange
            int quantidade = 1;
            double valorEsperado = 61.25;
            int tamanhoEsperado = 1;

            //Action
            pedidoSemItens.AdicionarPizza(quantidade, pizzaPequenaCalabresa, null, bordaPequenaCatupiry);

            //Assert
            pedidoSemItens.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            pedidoSemItens.ValorTotal.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_2_sabores_com_borda_catupiry_e_1_pizza_media_com_2_sabores_com_borda_cheedar()
        {
            //Arrange
            Produto pizzaMediaCalabresa = ObjectMother.ObterPizzaMediaDeCalabresa();
            
            int quantidade = 1;
            double valorEsperado = 147.75;
            int tamanhoEsperado = 2;

            //Action
            pedidoSemItens.AdicionarPizza(quantidade, pizzaPequenaCalabresa, pizzaPequenaCoracao, bordaPequenaCatupiry);
            pedidoSemItens.AdicionarPizza(quantidade, pizzaMediaMussarela, pizzaMediaCalabresa, bordaMediaCheddar);

            //Assert
            pedidoSemItens.ItensPedidos.Should().HaveCount(tamanhoEsperado);
            pedidoSemItens.ValorTotal.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_1_calzone()
        {
            //Arrange
            Produto calzone = ObjectMother.ObterCalzone();
            
            int quantidadeCalzone = 1;
            int quantidadePizza = 1;
            double valorEsperado = 75.00;

            //Action
            pedidoSemItens.AdicionarCalzone(quantidadeCalzone, calzone);
            pedidoSemItens.AdicionarPizza(quantidadePizza, pizzaPequenaCalabresa);

            //Assert
            pedidoSemItens.ItensPedidos.Should().HaveCount(2);
            pedidoSemItens.ValorTotal.Should().Be(valorEsperado);
        }

        [Test]
        public void Pedidos_Domain_Deve_calcular_valor_pedido_com_1_pizza_pequena_com_1_bebida()
        {
            //Arrange
            Produto bebida = ObjectMother.ObterBebida();
            
            int quantidadeBebida = 1;
            int quantidadePizza = 1;
            double valorEsperado = 68.00;

            //Action
            pedidoSemItens.AdicionarBebida(quantidadeBebida, bebida);
            pedidoSemItens.AdicionarPizza(quantidadePizza, pizzaPequenaCalabresa);

            //Assert
            pedidoSemItens.ItensPedidos.Should().HaveCount(2);
            pedidoSemItens.ValorTotal.Should().Be(valorEsperado);
        }
    }
}
