using Pizzaria.Domain.Features.ItensPedido;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.ItensPedido
{
    public class ItemPedidoSQLRepositorio : IItemPedidoRepositorio
    {
        private DataContext _contexto;

        public ItemPedidoSQLRepositorio(DataContext contexto)
        {
            _contexto = contexto;
        }

        public ItemPedido BuscarPorId(long id)
        {
            return _contexto.ItensPedidos.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Excluir(ItemPedido itemPedido)
        {
            _contexto.Entry(itemPedido).State = EntityState.Deleted;
            _contexto.ItensPedidos.Remove(itemPedido);
            _contexto.SaveChanges();
        }

        public IList<ItemPedido> Listagem()
        {
            return _contexto.ItensPedidos.ToList();
        }
    }
}
