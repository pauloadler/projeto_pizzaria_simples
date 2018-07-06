using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Infra.Data.Features.Produtos
{
    public class ProdutoSQLRepository : IProdutoRepositorio
    {
        DataContext _contexto;

        public ProdutoSQLRepository(DataContext contexto)
        {
            _contexto = contexto;
        }
        public Produto BuscarPorId(long id)
        {
            return _contexto.Produtos.Where(p => p.Id == id).FirstOrDefault();
        }

        public Produto Editar(Produto produto)
        {
            _contexto.Entry(produto).State = EntityState.Modified;
            _contexto.SaveChanges();

            return produto;
        }

        public Produto Salvar(Produto produto)
        {
            var produtoRetorno = _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
            return produtoRetorno;
        }

        public void Excluir(Produto produto)
        {
            _contexto.Entry(produto).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        public IList<Produto> Listagem()
        {
            return _contexto.Set<Produto>().ToList();
        }

        public List<Produto> BuscarPorTipo(TipoProdutoEnum Tipo)
        {
            return _contexto.Set<Produto>().ToList();
        }
    }
}
