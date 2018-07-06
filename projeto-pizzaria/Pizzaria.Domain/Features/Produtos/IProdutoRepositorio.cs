using Pizzaria.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Domain.Features.Produtos
{
    public interface IProdutoRepositorio
    {
        Produto Salvar(Produto produto);
        Produto Editar(Produto produto);
        Produto BuscarPorId(long Id);
        IList<Produto> Listagem();
        List<Produto> BuscarPorTipo(TipoProdutoEnum Tipo);
        void Excluir(Produto produto);
    }
}
