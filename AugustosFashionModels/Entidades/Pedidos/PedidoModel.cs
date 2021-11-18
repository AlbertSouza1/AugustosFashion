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
        public double TotalBruto 
        {
            get => Produtos.Sum(p => (p.PrecoVenda * p.Quantidade));
        }
        public double TotalDesconto
        {
            get => Produtos.Sum(p => (p.Desconto * p.Quantidade));
        }
        public double TotalLiquido
        {
            get => Produtos.Sum(p => p.Total);
        }
        public List<PedidoProdutoModel> Produtos { get; set; }
        public double Lucro
        {
            get => Produtos.Sum(p => p.Total) - Produtos.Sum(p => p.PrecoCusto * p.Quantidade);
        }

        public PedidoModel()
        {
            Produtos = new List<PedidoProdutoModel>();
        }
    }
}
