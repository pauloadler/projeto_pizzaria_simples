using Moq;
using NUnit.Framework;
using Pizzaria.Application.Features.Produtos;
using Pizzaria.Domain.Features.Produtos;

namespace Pizzaria.Application.Tests.Produtos
{
    [TestFixture]
    public class ProdutoServicoTest
    {
        Mock<IProdutoRepositorio> _produtoRepositorio;
        IProdutoServico _produtoServico;

        [SetUp]
        public void Inicializacao()
        {
            _produtoRepositorio = new Mock<IProdutoRepositorio>();
            _produtoServico = new ProdutoServico(_produtoRepositorio.Object);
        }

        [Test]
        public void Produtos_Servico_Deveria_incluir_um_novo_produto()
        {
            //Arrange

            //Action

            //Assert
        }

        [Test]
        public void Produtos_Servico_Deveria_atualizar_um_produto()
        {
            //Arrange

            //Action

            //Assert
        }

        [Test]
        public void Produtos_Servico_Deveria_excluir_um_produto()
        {
            //Arrange

            //Action

            //Assert
        }

        [Test]
        public void Produtos_Servico_Deveria_buscar_um_produto_pelo_id()
        {
            //Arrange

            //Action

            //Assert
        }

        [Test]
        public void Produtos_Servico_Deveria_buscar_todos_os_produtos()
        {
            //Arrange

            //Action

            //Assert
        }
    }
}
