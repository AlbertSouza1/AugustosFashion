using AugustosFashionModels.Entidades.Dinheiros;
using AugustosFashionModels.Entidades.NomesCompletos;
using System;
using System.ComponentModel;
using EnumsNET;

namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoListagem
    {
        public int IdPedido { get; set; }
        public DateTime DataEmissao { get; set; }
        public NomeCompleto NomeCliente { get; set; }
        public NomeCompleto NomeColaborador { get; set; }
        [Browsable(false)]
        public EFormaPagamento FormaPagamento { get; set; }
        public string FormaPagamentoDescription { get => FormaPagamento.AsString(EnumFormat.Description); }
        public Dinheiro TotalBruto { get; set; }
        public Dinheiro TotalDesconto { get; set; }
        public Dinheiro TotalLiquido { get; set; }
        public Dinheiro Lucro { get; set; }
    }
}
