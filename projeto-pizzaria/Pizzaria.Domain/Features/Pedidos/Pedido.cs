using Pizzaria.Domain.Enums;
using Pizzaria.Domain.Features.Clientes;
using Pizzaria.Domain.Features.ItensPedido;
using Pizzaria.Domain.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizzaria.Domain.Features.Pedidos
{
    public class Pedido
    {
        public Pedido()
        {
            ItensPedidos = new List<ItemPedido>();
        }

        public long Id { get; set; }
        public string Setor { get; set; }
        public string Responsavel { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public bool EmitirNFe { get; set; }
        public string Observacao { get; set; }
        public DateTime Data { get; set; } 
        public StatusPedidoEnum StatusPedido { get; set; }
        public List<ItemPedido> ItensPedidos { get; set; }

        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public virtual void Valida()
        {
            //Os dados Obrigatorios

            if (Cliente == null)
            {
                //Execeção
            }

            //Validação da Data menor que agora (Frescuragem)
            //if (Data)
            //{
            //
            //}

            if (ItensPedidos.Count > -1)
            {
                //Execeção
            }

    
            //Validações do Cliente
            switch (Cliente.TipoCliente)
            {
                case TipoClienteEnum.Fisico:

                    if (EmitirNFe)
                    {
                        //
                    }

                    break;

                case TipoClienteEnum.Juridico:

                    if (string.IsNullOrEmpty(Setor))
                    {

                    }

                    if (string.IsNullOrEmpty(Responsavel))
                    {

                    }


                    if (EmitirNFe)
                    {
                        //
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
            itemPedido.Valida();
            ItensPedidos.Add(itemPedido);
        }

        public void AdicionarCalzone(int quantidade, Produto calzone)
        {
            ItemPedido itemPedido = new ItemPedido(calzone, quantidade);
            itemPedido.Valida();
            ItensPedidos.Add(itemPedido);
        }

        public void AdicionarBebida(int quantidade, Produto bebida)
        {
            ItemPedido itemPedido = new ItemPedido(bebida, quantidade);
            itemPedido.Valida();
            ItensPedidos.Add(itemPedido);
        }
    }
}