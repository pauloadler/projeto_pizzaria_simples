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
        private Produto _produto;

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
            Produto produto = ObjectMother.ObterPizzaPequenaDeCalabresa();

            //Ação
            Produto resultado = _repositorio.Salvar(produto);

            //Verifica
            resultado.Should().NotBeNull();
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
            //Ação
            var produto = _repositorio.BuscarPorId(_produto.Id);

            //Verifica
            produto.Should().NotBeNull();
            produto.Id.Should().Equals(_produto.Id);
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
            long enderecoId = _produto.Id;
            _repositorio.Excluir(_produto);

            //Ação
            var produtoDB = _repositorio.BuscarPorId(_produto.Id);
            var enderecoAluno = _repositorio.BuscarPorId(enderecoId);

            //Verifica
            produtoDB.Should().BeNull();
            var AlunoContexto = _contexto.Produtos.Find(enderecoAluno.Id);
            AlunoContexto.Should().BeNull();
        }
    }
}
