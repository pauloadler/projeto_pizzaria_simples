using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Produtos;
using Pizzaria.Infra.Metodo_Extensao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzaria.Domain.Features.Pedidos
{
    public class Pedido
    {
        private int _igualA = 0;

        public long Id { get; set; }
        public string Setor { get; set; }
        public string Responsavel { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public bool EmitirNFe { get; set; }
        public string Observacao { get; set; }
        public DateTime Data { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
        public long ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }

    
    


        public Pedido()
        {
            ItensPedidos = new List<ItemPedido>();
        }

        public virtual void Validar()
        {
            if (Cliente == null)
            {
                throw new PedidoClienteNuloExcecao();
            }

            if (Data.CompararDataMenorQueAtual())
            {
                throw new PedidoDataMenorQueAtualExcecao();
            }

            if (ItensPedidos.Count == _igualA)
            {
                throw new PedidoItensPedidosVazioExcecao();
            }

            //Validações do Cliente
            switch (Cliente.TipoCliente)
            {
                case TipoClienteEnum.Fisico:

                    if (EmitirNFe)
                    {
                        // fazer a validação do Cliente do CPF.
                    }

                    break;

                case TipoClienteEnum.Juridico:

                    if (string.IsNullOrEmpty(Setor))
                    {
                        throw new PedidoSetorNuloOuVazioExcecao();
                    }

                    if (string.IsNullOrEmpty(Responsavel))
                    {
                        throw new PedidoResponsavelNuloOuVazioExcecao();
                    }


                    if (EmitirNFe)
                    {
                        // fazer a validação do Cliente do CNPJ.
                    }

                    break;
            }
        }

        public double ValorTotal
        {
            get
            {
                return ItensPedidos.Sum(x => x.ValorParcial);
            }
        }

        public void AdicionarPizza(int quantidade, Produto pizza1, Produto pizza2 = null, Produto adicional = null)
        {
            ItemPedido itemPedido = new ItemPedido(pizza1, pizza2, adicional, quantidade);
            itemPedido.Pedido = this;
            itemPedido.Validar();
            ItensPedidos.Add(itemPedido);
        }

        public void AdicionarCalzone(int quantidade, Produto calzone)
        {
            ItemPedido itemPedido = new ItemPedido(calzone, quantidade);
            itemPedido.Pedido = this;
            itemPedido.Validar();
            ItensPedidos.Add(itemPedido);
        }

        public void AdicionarBebida(int quantidade, Produto bebida)
        {
            ItemPedido itemPedido = new ItemPedido(bebida, quantidade);
            itemPedido.Pedido = this;
            itemPedido.Validar();
            ItensPedidos.Add(itemPedido);
        }
    }
}