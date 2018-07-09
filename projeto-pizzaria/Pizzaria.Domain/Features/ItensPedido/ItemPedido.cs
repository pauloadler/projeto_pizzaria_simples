using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Pedidos;
using Pizzaria.Domain.Features.Produtos;

using System;
using System.Linq;

namespace Pizzaria.Domain.Features.ItensPedido
{
    public class ItemPedido
    {
        private int _menorQue = 1;

        public long Id { get; set; }
        public int Quantidade { get; set; }
        public long PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public long PrimeiroProdutoId { get; set; }
        public virtual Produto PrimeiroProduto { get; set; }
        public long? SegundoProdutoId { get; set; }
        public virtual Produto SegundoProduto { get; set; }
        public long? AdicionalId { get; set; }
        public virtual Produto Adicional { get; set; }
   
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


        public virtual void Validar()
        {
            if (Pedido == null)
            {
                throw new ItemPedidoPedidoNullExcecao();
            }

            if (PrimeiroProduto == null)
            {
                throw new ItemPedidoPrimeiroProdutoNuloOuVazioExcecao();
            }

            if (Quantidade < _menorQue)
            {
                throw new ItemPedidoQuantidadeZeroExcecao();
            }

            if (Adicional != null && Adicional.Tipo != TipoProdutoEnum.Adicional)
            {
                throw new ItemPedidoAdicionalInvalidoExcecao();
            }
        }


        public double ValorParcial
        {
            get
            {
                return SomatorioValoresProdutos() * Quantidade;
            }
        }

        private double SomatorioValoresProdutos()
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

            return somatorio;
        }

        private double VerificaMaiorValor(params Produto[] produtos)
        {
            return produtos.Max(x => x.Valor);
        }
    }
}