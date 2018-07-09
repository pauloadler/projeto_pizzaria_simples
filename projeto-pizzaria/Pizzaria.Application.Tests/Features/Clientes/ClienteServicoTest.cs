using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Application.Features.Clientes;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Tests.Features.Clientes
{
    [TestFixture]
    public class ClienteServicoTest
    {
        private Mock<IClienteRepositorio> _mockRepositorio;
        private Mock<Endereco> _mockEndereco;
        private IClienteServico _servico;

        [SetUp]
        public void Inicializacao()
        {
            _mockEndereco = new Mock<Endereco>();
            _mockRepositorio = new Mock<IClienteRepositorio>();

            _servico = new ClienteServico(_mockRepositorio.Object);
        }

        [Test]
        public void Clientes_Application_Adicionar_cliente_tipo_pessoa_fisica()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_mockEndereco.Object);

            _mockRepositorio.Setup(m => m.Salvar(cliente)).Returns(new Cliente() { Id = 1 });

            //Ação
            Cliente resultado = _servico.Adicionar(cliente);

            //Verifica
            resultado.Should().NotBeNull();
            _mockRepositorio.Verify(repository => repository.Salvar(cliente));
        }

        [Test]
        public void Clientes_Application_Adicionar_cliente_com_nome_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComNomeNuloOuVazio(_mockEndereco.Object);

            //Ação
            Action action = () => _servico.Adicionar(cliente);

            //Verifica
            action.Should().Throw<ClienteNomeNuloOuVazioExcecao>();
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Clientes_Application_Atualizar_cliente()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_mockEndereco.Object);
            cliente.Id = 1;

            _mockRepositorio.Setup(m => m.Atualizar(cliente)).Returns(new Cliente() { Id = 1 });

            //Ação
            Cliente resultado = _servico.Atualizar(cliente);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(cliente.Id);
            _mockRepositorio.Verify(repository => repository.Atualizar(cliente));
        }

        [Test]
        public void Clientes_Application_Atualizar_cliente_com_telefone_nulo_ou_vazio()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteComTelefoneNuloOuVazio(_mockEndereco.Object);
            cliente.Id = 1;

            //Ação
            Action action = () => _servico.Atualizar(cliente);

            //Verifica
            action.Should().Throw<ClienteTelefoneNuloOuVazioExcecao>();
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Clientes_Application_Atualizar_cliente_com_id_invalido()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_mockEndereco.Object);

            //Ação
            Action action = () => _servico.Atualizar(cliente);

            //Verifica
            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Clientes_Application_Buscar_cliente_por_id()
        {
            //Cenário
            int id = 1;

            _mockRepositorio.Setup(m => m.BuscarPorId(id)).Returns(new Cliente() { Id = 1 });

            //Ação
            Cliente resultado = _servico.BuscarPorId(id);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(id);
            _mockRepositorio.Verify(repository => repository.BuscarPorId(id));
        }

        [Test]
        public void Clientes_Application_Buscar_cliente_por_id_com_id_invalido()
        {
            //Cenário
            int id = 0;

            //Ação
            Action action = () => _servico.BuscarPorId(id);

            //Verifica
            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Clientes_Application_Buscar_cliente_por_telefone()
        {
            //Cenário
            string telefone = "999999999";

            _mockRepositorio.Setup(m => m.BuscarPorTelefone(telefone)).Returns(new Cliente() { Id = 1, Telefone = "999999999" });

            //Ação
            Cliente resultado = _servico.BuscarPorTelefone(telefone);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Telefone.Should().Be(telefone);
            _mockRepositorio.Verify(repository => repository.BuscarPorTelefone(telefone));
        }

        [Test]
        public void Clientes_Application_Buscar_cliente_por_telefone_com_telefone_nulo()
        {
            //Cenário
            string telefone = null;

            //Ação
            Action action = () => _servico.BuscarPorTelefone(telefone);

            //Verifica
            action.Should().Throw<ClienteTelefoneNuloOuVazioExcecao>();
            _mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Clientes_Application_Listar_todos_os_clientes()
        {
            //Cenário
            _mockRepositorio.Setup(m => m.Listagem()).Returns(new List<Cliente>() { new Cliente() { Id = 1 } });

            //Ação
            List<Cliente> clientes = _servico.Listagem();

            //Verifica
            clientes.Should().NotBeNull();
            _mockRepositorio.Verify(repository => repository.Listagem());
        }

        [Test]
        public void Clientes_Application_Excluir_cliente()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_mockEndereco.Object);
            cliente.Id = 1;

            _mockRepositorio.Setup(m => m.Excluir(cliente));

            //Ação
            _servico.Excluir(cliente);

            //Verifica
            _mockRepositorio.Verify(repository => repository.Excluir(cliente));
        }

        [Test]
        public void Clientes_Application_Excluir_cliente_com_id_invalido()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_mockEndereco.Object);

            //Ação
            Action action = () => _servico.Excluir(cliente);

            //Verifica
            action.Should().Throw<IdentifierUndefinedException>();
            _mockRepositorio.VerifyNoOtherCalls();
        }
    }
}
