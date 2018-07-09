using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Tests.Base;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Infra.Data.Features.ItensPedido;
using Pizzaria.Infra.Data.Features.Pedidos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Tests.Features.ItemsPedido
{
    [TestFixture]
    public class PedidoSQLRepositorioTest
    {
        private IItemPedidoRepositorio _repositorio;
        private DataContext _contexto;

        [SetUp]
        public void Inicializacao()
        {
            _contexto = new DataContext();
            Database.SetInitializer(new CriarBaseDeDados());
            _contexto.Database.Initialize(true);

            _repositorio = new ItemPedidoSQLRepositorio(_contexto);
        }

        [Test]
        public void ItemsPedido_InfraData_Deve_buscar_por_id_Item_pedido()
        {
            //Cenário
            long idProcura = 1;

            //Ação
            ItemPedido item = _repositorio.BuscarPorId(idProcura);

            //Verifica
            item.Should().NotBeNull();
            item.Id.Should().Be(idProcura);
        }

        [Test]
        public void ItemsPedido_InfraData_Deve_deletar_Item_pedido()
        {
            //Cenário
            long idProcura = 1;
            ItemPedido item = _repositorio.BuscarPorId(idProcura);

            //Ação
            _repositorio.Excluir(item);

            //Verifica
            ItemPedido resultado = _repositorio.BuscarPorId(idProcura);
            resultado.Should().BeNull();
        }


        [Test]
        public void ItemsPedido_InfraData_Deve_listar_os_Itens_pedido()
        {
            //Cenário
            int tamanhoLista = 1;

            //Ação
            var lista = _repositorio.Listagem();

            //Verifica
            lista.Should().NotBeNull();
            lista.Should().HaveCount(tamanhoLista);
        }
    }
}
