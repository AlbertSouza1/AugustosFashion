using System;
using System.Collections.Generic;

namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoModel
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdColaborador { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataEmissao { get; set; }
        public double TotalBruto { get; set; }
        public double TotalDesconto { get; set; }
        public double TotalLiquido { get; set; }
        public List<PedidoProdutoModel> Produtos { get; set; }
    }
}
