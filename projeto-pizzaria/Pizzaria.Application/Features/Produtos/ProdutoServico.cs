using System.Collections.Generic;
using Pizzaria.Domain.Features.Produtos;

namespace Pizzaria.Application.Features.Produtos
{
    public class ProdutoServico : IProdutoServico
    {
        private IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto Adicionar(Produto entidade)
        {
            throw new System.NotImplementedException();
        }

        public Produto Atualizar(Produto entidade)
        {
            throw new System.NotImplementedException();
        }

        public Produto BuscarPorId(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Produto entidade)
        {
            throw new System.NotImplementedException();
        }

        public List<Produto> Listagem()
        {
            throw new System.NotImplementedException();
        }
    }
}
