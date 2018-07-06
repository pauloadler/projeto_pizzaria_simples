using Pizzaria.Domain.Features.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.Pedidos
{
    public class PedidoSQLRepositorio : IPedidoRepositorio
    {
        private DataContext _contexto;

        public PedidoSQLRepositorio(DataContext contexto)
        {
            _contexto = contexto;
        }

        public Pedido Salvar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido Atualizar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IList<Pedido> Listagem()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
