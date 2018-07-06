using Pizzaria.Domain.Enums;
using System.Collections.Generic;

namespace Pizzaria.Domain.Features.Produtos
{
    public class Produto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public TipoProdutoEnum Tipo { get; set; }
        public TamanhoProdutoEnum Tamanho { get; set; }
        public double Valor { get; set; }
    }
}