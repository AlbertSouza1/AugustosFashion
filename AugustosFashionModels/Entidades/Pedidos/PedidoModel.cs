﻿using AugustosFashionModels.Entidades.Dinheiros;
using AugustosFashionModels.Entidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoModel
    {      
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdColaborador { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataEmissao { get; set; }
        public Dinheiro TotalBruto 
        {
            get => Produtos.Sum(p => (p.PrecoVenda.RetornaValor * p.Quantidade));
        }
        public Dinheiro TotalDesconto
        {
            get => Produtos.Sum(p => (p.Desconto.RetornaValor * p.Quantidade));
        }
        public Dinheiro TotalLiquido
        {
            get => Produtos.Sum(p => p.Total.RetornaValor);
        }
        public List<ProdutoCarrinho> Produtos { get; set; }
        public Dinheiro Lucro
        {
            get => Produtos.Sum(p => p.Total.RetornaValor) - Produtos.Sum(p => p.PrecoCusto.RetornaValor * p.Quantidade);
        }

        public PedidoModel()
        {
            Produtos = new List<ProdutoCarrinho>();
        }
    }
}
