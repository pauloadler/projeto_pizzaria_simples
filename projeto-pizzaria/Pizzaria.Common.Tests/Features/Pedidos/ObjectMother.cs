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
        public static Pedido GetPedidoSemUmaListaItens(Cliente cliente)
        {
            return new Pedido()
            {
                Data = DateTime.Now,
                Cliente = cliente,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
            };
        }

        public static Pedido GetPedidoComUmaListaItens(Cliente cliente, List<ItemPedido> itensPedidos)
        {
            return new Pedido
            {
                Data = DateTime.Now,
                Cliente = cliente,
                ItensPedidos = itensPedidos,
                EmitirNFe = false,
                FormaPagamento = FormaPagamentoEnum.Dinheiro,
                StatusPedido = StatusPedidoEnum.AguardandoEntrega,
            };
        }

    }
}
