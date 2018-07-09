using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Application.Features.ItensPedido
{
    public interface IItensPedidoServico
    {
        ItemPedido BuscarPorId(long id);
        List<ItemPedido> Listagem();
        void Excluir(ItemPedido entidade);
    }
}
