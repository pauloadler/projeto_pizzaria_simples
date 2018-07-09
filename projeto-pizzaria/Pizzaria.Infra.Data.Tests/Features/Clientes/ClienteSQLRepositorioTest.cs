﻿using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.Enderecos;
using Pizzaria.Infra.CNPJs;
using Pizzaria.Infra.CPFs;
using Pizzaria.Infra.Data.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Tests.Features.Clientes
{
    [TestFixture]
    public class ClienteSQLRepositorioTest
    {
        private IClienteRepositorio _repositorio;
        private DataContext _contexto;
        private Endereco _endereco;


        [SetUp]
        public void Inicializacao()
        {
            _contexto = new DataContext();
            Database.SetInitializer(new CriarBaseDeDados());
            _contexto.Database.Initialize(true);

            _endereco = ObjectMother.ObterEndereco();

            _repositorio = new ClienteSQLRepositorio(_contexto);
        }

        [Test]
        public void Clientes_InfraData_Salvar_cliente_tipo_pessoa_fisica()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaFisica(_endereco);

            int id = 4;

            //Ação
            Cliente resultado = _repositorio.Salvar(cliente);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(id);
        }

        [Test]
        public void Clientes_InfraData_Salvar_cliente_tipo_pessoa_juridica()
        {
            //Cenário
            Cliente cliente = ObjectMother.ObterClienteTipoPessoaJuridica(_endereco);

            int id = 4;

            //Ação
            Cliente resultado = _repositorio.Salvar(cliente);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(id);
        }

        [Test]
        public void Clientes_InfraData_Atualizar_cliente()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _repositorio.BuscarPorId(idPesquisa);
            string nomeAntigo = cliente.Nome;
            cliente.Nome = "Novo";

            //Ação
            Cliente resultado = _repositorio.Atualizar(cliente);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Nome.Should().NotBe(nomeAntigo);
        }

        [Test]
        public void Clientes_InfraData_Buscar_cliente_por_id()
        {
            //Cenário
            int idPesquisa = 1;

            //Ação
            Cliente resultado = _repositorio.BuscarPorId(idPesquisa);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idPesquisa);
        }

        [Test]
        public void Clientes_InfraData_Buscar_cliente_por_telefone()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _repositorio.BuscarPorId(idPesquisa);
            string telefonePesquisa = cliente.Telefone;

            //Ação
            Cliente resultado = _repositorio.BuscarPorTelefone(telefonePesquisa);

            //Verifica
            resultado.Should().NotBeNull();
            resultado.Id.Should().Be(idPesquisa);
            resultado.Telefone.Should().Be(telefonePesquisa);
        }

        [Test]
        public void Clientes_InfraData_Buscar_todos_os_clientes()
        {
            //Cenário
            int tamanhoLista = 3;

            //Ação
            IList<Cliente> clientes = _repositorio.Listagem();

            //Verifica
            clientes.Should().NotBeNull();
            clientes.Count.Should().Be(tamanhoLista);
        }

        [Test]
        public void Clientes_InfraData_Excluir_cliente()
        {
            //Cenário
            int idPesquisa = 1;
            Cliente cliente = _repositorio.BuscarPorId(idPesquisa);

            //Ação
            _repositorio.Excluir(cliente);

            //Verifica
            Cliente resultado = _repositorio.BuscarPorId(idPesquisa);
            resultado.Should().BeNull();
        }
    }
}
