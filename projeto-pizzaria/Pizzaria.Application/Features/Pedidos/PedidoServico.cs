using System;
using System.Collections.Generic;
using Pizzaria.Domain.Features.Pedidos;

namespace Pizzaria.Application.Features.Pedidos
{
    public class PedidoServico : IPedidoServico
    {
        private IPedidoRepositorio _repositorio;

        public PedidoServico(IPedidoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Pedido Adicionar(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public Pedido Atualizar(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> Listagem()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Pedido entidade)
        {
            throw new NotImplementedException();
        }
    }
}
