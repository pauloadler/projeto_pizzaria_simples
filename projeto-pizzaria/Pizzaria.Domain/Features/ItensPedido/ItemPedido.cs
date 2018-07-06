using Pizzaria.Domain.Features.Produtos;
using System;
using System.Linq;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedido
    {
        public long Id { get; set; }
        public int Quantidade { get; set; }
        public Produto PrimeiroProduto { get; set; }
        public Produto SegundoProduto { get; set; }
        public Produto Adicional { get; set; }

        public ItemPedido()
        {
            Quantidade = 1;
        }

        public ItemPedido(Produto produto, int quantidade)
        {
            PrimeiroProduto = produto;
            Quantidade = quantidade;
        }

        public ItemPedido(Produto primeiraPizza, Produto segundaPizza, Produto adicional, int quantidade)
        {
            PrimeiroProduto = primeiraPizza;
            SegundoProduto = segundaPizza;
            Adicional = adicional;
            Quantidade = quantidade;
        }

        public double ValorParcial
        {
            get
            {
                double somatorio = 0;

                if (SegundoProduto != null)
                {
                    somatorio = VerificaMaiorValor(PrimeiroProduto, SegundoProduto);
                }
                else
                {
                    somatorio = PrimeiroProduto.Valor;
                }
                
                somatorio += Adicional == null ? 0 : Adicional.Valor;

                return somatorio * Quantidade;
            }
        }

        public virtual void Valida()
        {
        }

        private double VerificaMaiorValor(params Produto[] produtos)
        {
            return produtos.Max(x => x.Valor);
        }
    }
}