using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Application.Features.Pedidos;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Data;
using Pizzaria.Infra.Data.Features.Pedidos;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Pizzaria.Integration.Tests.Pedidos
{
    [TestFixture]
    public class PedidoIntegracaoTest
    {
        private DataContext _contexto;
        private IPedidoRepositorio _repositorio;
        
        private PedidoServico _servico;
        private Cliente cliente;
        private List<ItemPedido> listaItemPedido;
        private Pedido _pedido;
        private Produto calzone;

        [SetUp]
        public void Inicializacao()
        {
            Database.SetInitializer(new CriarBaseDeDados());
            _contexto = new DataContext();
            _contexto.Database.Initialize(true);

            _repositorio = new PedidoSQLRepositorio(_contexto);
           
            _servico = new PedidoServico(_repositorio);

            cliente = ObjectMother.ObterClienteTipoPessoaFisica(ObjectMother.ObterEndereco());
            cliente.Id = 1;

            calzone = ObjectMother.ObterCalzone();
            calzone.Id = 1;

            listaItemPedido = new List<ItemPedido>();
            listaItemPedido.Add(new ItemPedido(calzone,2));

            _pedido = ObjectMother.ObterPedidoComUmaListaItens(cliente, listaItemPedido);
        }

        [Test]
        public void Pedidos_Integration_Deve_adicionar_um_pedido()
        {
            //Cenário
            long idEsperado = 2;

            //Ação
            Pedido pedido = _servico.Adicionar(_pedido);

            //Verificação
            pedido.Id.Should().Be(idEsperado);
            
        }

        [Test]
        public void Pedidos_Integration_Nao_deve_adicionar_um_pedido_com_cliente_nulo()
        {
            //Cenário
            _pedido = ObjectMother.ObterPedidoComClienteNulo(listaItemPedido);

            //Ação
            Action acao = () => _servico.Adicionar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoClienteNuloExcecao>();

        }


        [Test]
        public void Pedidos_Integration_Nao_deve_adicionar_um_pedido_com_a_data_menor_que_atual()
        {
            //Cenário
            _pedido = ObjectMother.ObterPedidoDataMenorQueAtual(cliente,listaItemPedido);

            //Ação
            Action acao = () => _servico.Adicionar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoDataMenorQueAtualExcecao>();

        }

        [Test]
        public void Pedidos_Integration_Nao_deve_adicionar_um_pedido_com_lista_item_pedidos_vazia()
        {
            //Cenário
            _pedido = ObjectMother.ObterPedidoSemUmaListaItens(cliente);

            //Ação
            Action acao = () => _servico.Adicionar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoItensPedidosVazioExcecao>();
        }

        [Test]
        public void Pedidos_Integration_Nao_deve_adicionar_um_pedido_de_uma_empresa_sem_o_setor()
        {
            //Cenário
            cliente = ObjectMother.ObterClienteTipoPessoaJuridica(ObjectMother.ObterEndereco());
            _pedido = ObjectMother.ObterPedidoSetorNuloOuVazio(cliente, listaItemPedido);

            //Ação
            Action acao = () => _servico.Adicionar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoSetorNuloOuVazioExcecao>();
        }

        [Test]
        public void Pedidos_Integration_Nao_deve_adicionar_um_pedido_de_uma_empresa_sem_o_responsavel()
        {
            //Cenário
            cliente = ObjectMother.ObterClienteTipoPessoaJuridica(ObjectMother.ObterEndereco());
            _pedido = ObjectMother.ObterPedidoResponsavelNuloOuVazio(cliente, listaItemPedido);

            //Ação
            Action acao = () => _servico.Adicionar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoResponsavelNuloOuVazioExcecao>();
        }

        [Test]
        public void Pedidos_Integration_Deve_atualizar_um_pedido()
        {
            //Cenário
            long idProcura = 1;
            _pedido = _servico.BuscarPorId(idProcura);

            StatusPedidoEnum novoStatus = StatusPedidoEnum.EmEntrega;
            _pedido.StatusPedido = novoStatus;

            //Ação
            _servico.Atualizar(_pedido);

            //Verificação
            Pedido pedido = _servico.BuscarPorId(idProcura);
            pedido.Should().NotBeNull();
            pedido.StatusPedido.Should().Be(novoStatus);

        }

        [Test]
        public void Pedidos_Integration_Nao_deve_atualizar_um_pedido_com_id_invalido()
        {
            //Cenário
            StatusPedidoEnum novoStatus = StatusPedidoEnum.EmEntrega;
            _pedido.StatusPedido = novoStatus;

            //Ação
            Action acao = () => _servico.Atualizar(_pedido);

            //Verificação
            acao.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Pedidos_Integration_Nao_deve_atualizar_um_pedido_com_cliente_nulo()
        {
            //Cenário
            _pedido = ObjectMother.ObterPedidoComClienteNulo(listaItemPedido);
            _pedido.Id = 1;
            //Ação
            Action acao = () => _servico.Atualizar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoClienteNuloExcecao>();

        }

        [Test]
        public void Pedidos_Integration_Nao_deve_atualizar_um_pedido_com_a_data_menor_que_atual()
        {
            //Cenário
            _pedido = ObjectMother.ObterPedidoDataMenorQueAtual(cliente, listaItemPedido);
            _pedido.Id = 1;

            //Ação
            Action acao = () => _servico.Atualizar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoDataMenorQueAtualExcecao>();

        }

        [Test]
        public void Pedidos_Integration_Nao_deve_atualizar_um_pedido_com_lista_item_pedidos_vazia()
        {
            //Cenário
            _pedido = ObjectMother.ObterPedidoSemUmaListaItens(cliente);
            _pedido.Id = 1;

            //Ação
            Action acao = () => _servico.Atualizar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoItensPedidosVazioExcecao>();
        }

        [Test]
        public void Pedidos_Integration_Nao_deve_atualizar_um_pedido_de_uma_empresa_sem_o_setor()
        {
            //Cenário
            cliente = ObjectMother.ObterClienteTipoPessoaJuridica(ObjectMother.ObterEndereco());
            _pedido = ObjectMother.ObterPedidoSetorNuloOuVazio(cliente, listaItemPedido);
            _pedido.Id = 1;

            //Ação
            Action acao = () => _servico.Atualizar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoSetorNuloOuVazioExcecao>();
        }

        [Test]
        public void Pedidos_Integration_Nao_deve_atualizar_um_pedido_de_uma_empresa_sem_o_responsavel()
        {
            //Cenário
            cliente = ObjectMother.ObterClienteTipoPessoaJuridica(ObjectMother.ObterEndereco());
            _pedido = ObjectMother.ObterPedidoResponsavelNuloOuVazio(cliente, listaItemPedido);
            _pedido.Id = 1;

            //Ação
            Action acao = () => _servico.Atualizar(_pedido);

            //Verificação
            acao.Should().Throw<PedidoResponsavelNuloOuVazioExcecao>();
        }

        [Test]
        public void Pedidos_Application_Deve_exluir_um_pedido()
        {
            //Cenário
            long idProcura = 1;
            _pedido = _servico.BuscarPorId(idProcura);

            //Ação
            _servico.Excluir(_pedido);

            //Verificação
            Pedido pedido = _servico.BuscarPorId(idProcura);
            pedido.Should().BeNull();
        }

        [Test]
        public void Pedidos_Integration_Nao_deve_exluir_um_pedido_com_id_invalido()
        {
            //Cenário
            _pedido.Id = 0;

            //Ação
            Action acao = () => _servico.Excluir(_pedido);

            //Verificação
            acao.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Pedidos_Integration_Deve_buscar_por_id_um_pedido()
        {
            //Cenário
            long idProcura = 1;

            //Ação
            Pedido pedido = _servico.BuscarPorId(idProcura);

            //Verificação
            pedido.Should().NotBeNull();
            pedido.Id.Should().Be(idProcura);
            pedido.Cliente.Should().NotBeNull();
            pedido.ItensPedidos.Should().NotBeNull();
        }

        [Test]
        public void Pedidos_Integration_Nao_deve_buscar_por_id_um_pedido_com_chave_de_produra_invalida()
        {
            //Cenário
            long idProcura = 0;

            //Ação
            Action acao = () => _servico.BuscarPorId(idProcura);

            //Verificação
            acao.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Pedidos_Application_Deve_listar_os_pedidos()
        {
            //Cenário
            int tamanhoLista = 1;

            //Ação
            var lista = _servico.Listagem();

            //Verificação
            lista.Should().NotBeNull();
            lista.Should().HaveCount(tamanhoLista);

        }
    }
}
