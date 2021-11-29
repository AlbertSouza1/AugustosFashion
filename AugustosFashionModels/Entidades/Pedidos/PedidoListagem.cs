using AugustosFashionModels.Entidades.Dinheiros;
using AugustosFashionModels.Entidades.NomesCompletos;
using System;

namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoListagem
    {
        public int IdPedido { get; set; }
        public DateTime DataEmissao { get; set; }
        public NomeCompleto NomeCliente { get; set; }
        public NomeCompleto NomeColaborador { get; set; }
        public string FormaPagamento { get; set; }
        public Dinheiro TotalBruto { get; set; }
        public Dinheiro TotalDesconto { get; set; }
        public Dinheiro TotalLiquido { get; set; }
        public Dinheiro Lucro { get; set; }
    }
}
