using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using System;
using System.Collections.Generic;

namespace Pizzaria.Common.Tests.Base
{
    public partial class ObjectMother
    {
        public static Pedido ObterPedidoSemUmaListaItens(Cliente cliente)
        {
            return new Pedido()
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who"
            };
        }

        public static Pedido ObterPedidoComUmaListaItens(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who"
            };
        }

        public static Pedido ObterPedidoComClienteNulo(List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who"
            };
        }

       public static Pedido ObterPedidoDataMenorQueAtual(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
                Responsavel = "Doctor Who"
            };
        }

        public static Pedido ObterPedidoSetorNuloOuVazio(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Responsavel = "Doctor Who"
            };
        }

        public static Pedido ObterPedidoResponsavelNuloOuVazio(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now.AddHours(4),
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
                Setor = "Setor X",
            };
        }

    }
}
