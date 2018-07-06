using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoSQLRepositorioTest
    {
        private IProdutoRepositorio _repositorio;
        private DataContext _contexto;

        [SetUp]
        public void Inicializacao()
        {

            _contexto = new DataContext();
            Database.SetInitializer(new CriarBaseDeDados());
            _contexto.Database.Initialize(true);

            _repositorio = new ProdutoSQLRepository(_contexto);
        }

        [Test]
        public void Produto_InfraData_Salvar_Pizza_Pequena_De_Calabresa()
        {
            //Cenário
            long idExperado = 2;
            Produto produto = ObjectMother.ObterPizzaPequenaDeCalabresa();

            //Ação
            Produto resultado = _repositorio.Salvar(produto);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idExperado);
        }

        [Test]
        public void Produtos_InfraData_Deve_Buscar_Por_Um_Tipo_De_Produto()
        {
            //Ação
            List<Produto> produtos = _repositorio.BuscarPorTipo(TipoProdutoEnum.Pizza);

            //Verifica
            produtos.Should().NotBeNull();
            produtos.Should().HaveCount(1);
        }

        [Test]
        public void Produtos_InfraData_Deve_Buscar_Por_Um_Id_De_Produto()
        {
            //Cenario
            long idProcura = 1;
            //Ação
            var produto = _repositorio.BuscarPorId(idProcura);

            //Verifica
            produto.Should().NotBeNull();
            produto.Id.Should().Equals(idProcura);
        }

        [Test]
        public void Produtos_InfraData_Deve_Atualizar_Produto()
        {
            //Cenário
            int idPesquisa = 1;
            Produto produto = _repositorio.BuscarPorId(idPesquisa);
            string descricaoAntiga = produto.Descricao;
            produto.Descricao = "DescricaoNova";

            //Ação
            Produto resultado = _repositorio.Editar(produto);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Descricao.Should().NotBe(descricaoAntiga);
        }

        [Test]
        public void Produtos_InfraData_Deve_Buscar_Todos_Produtos()
        {
            //Ação
            var produtos = _repositorio.Listagem();

            //Verifica
            produtos.Should().NotBeNull();
            produtos.Should().HaveCount(_contexto.Produtos.Count());
        }

        [Test]
        public void Produtos_InfraData_Deve_Deletar_Um_Produto()
        {
            //Cenário
            long idProduto = 1;
            var produto = _repositorio.BuscarPorId(idProduto);

            //Ação
            _repositorio.Excluir(produto);

            //Verifica
            var produtoDB = _repositorio.BuscarPorId(idProduto);
            produtoDB.Should().BeNull();
           
        }
    }
}
