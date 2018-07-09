using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Pizzaria.Domain.Exceptions;
using Pizzaria.Domain.Features.ItensPedido;

namespace Pizzaria.Application.Features.ItensPedido
{
    public class ItensPedidoServico : IItensPedidoServico
    {
        private IItemPedidoRepositorio _repositorio;
        private int menorQue = 1;

        public ItensPedidoServico(IItemPedidoRepositorio reposiotio)
        {
            _repositorio = reposiotio;
        }

        public ItemPedido BuscarPorId(long id)
        {
            if (id < menorQue)
                throw new IdentifierUndefinedException();

            return _repositorio.BuscarPorId(id);
        }

        public void Excluir(ItemPedido entidade)
        {
            if (entidade.Id < menorQue)
                throw new IdentifierUndefinedException();

            _repositorio.Excluir(entidade);
        }

        public List<ItemPedido> Listagem()
        {
            return _repositorio.Listagem() as List<ItemPedido>;
        }
    }
}