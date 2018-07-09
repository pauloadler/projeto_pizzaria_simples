using Moq;
using NUnit.Framework;
using Pizzaria.Domain.Features.Pedidos;

namespace Pizzaria.Application.Tests.Pedidos
{
    [TestFixture]
    public class PedidoServicoTest
    {
        private Mock<IPedidoRepositorio> _repositorio;
        private Pedido _pedido;

        [SetUp]
        public void Inicializacao()
        {
            _repositorio = new Mock<IPedidoRepositorio>();
         
        }

        [Test]
        public void Pedidos_Aplicacao_Deve_adicionar_com_sucesso()
        {
            //Cenário

        }
    }
}
